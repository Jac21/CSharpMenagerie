using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using ReliableKafkaProducer.Core;
using ReliableKafkaProducer.Enums;
using ReliableKafkaProducer.Messages;
using ReliableKafkaProducer.Models;

namespace ReliableKafkaProducer
{
    /// <summary>
    /// https://github.com/confluentinc/confluent-kafka-dotnet
    /// https://github.com/rahulrai-in/kafka-lms
    /// </summary>
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, Kafka!");

            var adminConfig = new AdminClientConfig
            {
                BootstrapServers = "127.0.0.1:9092"
            };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = "http://127.0.0.1:8081"
            };

            var leaveApplicationRecievedMessages = new Queue<KafkaMessage>();

            using var adminClient = new AdminClientBuilder(adminConfig).Build();

            try
            {
                await adminClient.CreateTopicsAsync(new[]
                {
                    new TopicSpecification
                    {
                        Name = "leave-applications",
                        ReplicationFactor = 1,
                        NumPartitions = 3
                    }
                });
            }
            catch (CreateTopicsException e) when (e.Results.Select(r => r.Error.Code)
                                                      .Any(el => el == ErrorCode.TopicAlreadyExists))
            {
                Console.WriteLine($"Topic {e.Results[0].Topic} already exists");
            }

            // access the schema registry
            using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

            switch (args.FirstOrDefault())
            {
                case "p":
                    await InitiateProducer(schemaRegistry);
                    break;
                case "c":
                    InitiateConsumer(schemaRegistry, leaveApplicationRecievedMessages);
                    break;
                default:
                    Console.WriteLine("Enter either 'p' to initiate producer, or 'c' to initiate consumer");
                    break;
            }
        }

        private static async Task InitiateProducer(ISchemaRegistryClient schemaRegistry)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "127.0.0.1:9092",
                // Guarantees delivery of message to topic.
                EnableDeliveryReports = true,
                ClientId = Dns.GetHostName()
            };

            // embed Avro serializers into the producer instance
            using var producer = new ProducerBuilder<string, LeaveApplicationReceived>(producerConfig)
                .SetKeySerializer(new AvroSerializer<string>(schemaRegistry))
                .SetValueSerializer(new AvroSerializer<LeaveApplicationReceived>(schemaRegistry))
                .Build();

            while (true)
            {
                const string empDepartment = "IT";

                const string empEmail = "jcantu521@gmail.com";

                var leaveApplication = new LeaveApplicationReceived
                {
                    EmpDepartment = empDepartment,
                    EmpEmail = empEmail,
                    LeaveDurationInHours = 8,
                    LeaveStartDateTicks = DateTime.UtcNow.Ticks
                };

                var partition = new TopicPartition(ApplicationConstants.LeaveApplicationsTopicName,
                    new Partition((int) Enum.Parse<Departments>(empDepartment)));

                // send the message to the relevant partition of the topic
                var result = await producer.ProduceAsync(partition, new Message<string, LeaveApplicationReceived>()
                {
                    Key = $"{empEmail}-{DateTime.UtcNow.Ticks}",
                    Value = leaveApplication
                });

                Console.WriteLine(
                    $"\nMsg: Your leave request is queued at offset {result.Offset.Value} in the Topic {result.Topic}:{result.Partition.Value}\n\n");
            }
        }

        private static void InitiateConsumer(ISchemaRegistryClient schemaRegistry,
            Queue<KafkaMessage> leaveApplicationRecievedMessages)
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "127.0.0.1:9092",
                GroupId = "manager",
                EnableAutoCommit = false,
                EnableAutoOffsetStore = false,
                // Read messages from start if no commit exists.
                AutoOffsetReset = AutoOffsetReset.Earliest,
                MaxPollIntervalMs = 10000
            };

            // embed Avro serializers into the consumer instance
            using var consumer = new ConsumerBuilder<string, LeaveApplicationReceived>(consumerConfig)
                .SetKeyDeserializer(new AvroDeserializer<string>(schemaRegistry).AsSyncOverAsync())
                .SetValueDeserializer(new AvroDeserializer<LeaveApplicationReceived>(schemaRegistry).AsSyncOverAsync())
                .SetErrorHandler((_, e) => Console.WriteLine($"Errpr: {e.Reason}"))
                .Build();

            try
            {
                consumer.Subscribe("leave-applications");
                Console.WriteLine("Consumer loop started...\n");

                while (true)
                {
                    try
                    {
                        // We will give the process 1 second to commit the message and store its offset.
                        var result =
                            consumer.Consume(
                                TimeSpan.FromMilliseconds((double) (consumerConfig.MaxPollIntervalMs - 1000)));

                        var leaveRequest = result?.Message?.Value;

                        if (leaveRequest == null)
                        {
                            continue;
                        }

                        // Adding message to a list just for the demo.
                        // You should persist the message in database and process it later.
                        leaveApplicationRecievedMessages.Enqueue(new KafkaMessage()
                        {
                            Key = result.Message.Key,
                            Message = result.Message.Value,
                            Partition = result.Partition.Value
                        });

                        // ensure we don't end up processing several messages again after disruption
                        consumer.Commit(result);
                        consumer.StoreOffset(result);
                    }
                    catch (ConsumeException e) when (!e.Error.IsFatal)
                    {
                        Console.WriteLine($"Non fatal error: {e}");
                    }
                }
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}