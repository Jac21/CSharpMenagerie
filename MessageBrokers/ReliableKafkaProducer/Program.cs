using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using ReliableKafkaProducer.Core;
using ReliableKafkaProducer.Enums;
using ReliableKafkaProducer.Models;

namespace ReliableKafkaProducer
{
    public class Program
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

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "127.0.0.1:9092",
                // Guarantees delivery of message to topic.
                EnableDeliveryReports = true,
                ClientId = Dns.GetHostName()
            };

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
    }
}