using System.Text.Json;
using Confluent.Kafka;
using KafkaConsumer.Requests;

namespace KafkaConsumer.Services;

public class KafkaConsumerService : IHostedService
{
    private const string Topic = "testtopic";
    private const string GroupId = "test_group";
    private const string DockerBootstrapServers = "kafka:9092";

    private readonly ILogger<KafkaConsumerService> _logger;

    public KafkaConsumerService(ILogger<KafkaConsumerService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _logger.LogInformation($"Constructing {nameof(KafkaConsumerService)}");
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(KafkaConsumerService)}: Calling {nameof(StartAsync)}");

        var config = new ConsumerConfig
        {
            GroupId = GroupId,
            BootstrapServers = DockerBootstrapServers,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            AllowAutoCreateTopics = true
        };

        try
        {
            using var consumerBuilder = new ConsumerBuilder
                <Ignore, string>(config).Build();

            consumerBuilder.Subscribe(Topic);

            var cancelToken = new CancellationTokenSource();

            try
            {
                while (true)
                {
                    var consumer = consumerBuilder.Consume
                        (cancelToken.Token);

                    var orderRequest = JsonSerializer.Deserialize
                        <OrderProcessingRequest>
                        (consumer.Message.Value);

                    _logger.LogInformation(
                        $"{nameof(KafkaConsumerService)}.{nameof(StartAsync)}: Processing Order Id {orderRequest?.OrderId}");
                }
            }
            catch (OperationCanceledException)
            {
                consumerBuilder.Close();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: {ExMessage}", ex.Message);
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}