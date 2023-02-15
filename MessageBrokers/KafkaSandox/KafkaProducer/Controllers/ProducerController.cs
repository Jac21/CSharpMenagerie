using System.Net;
using System.Text.Json;
using Confluent.Kafka;
using KafkaProducer.Requests;
using Microsoft.AspNetCore.Mvc;

namespace KafkaProducer.Controllers;

[ApiController]
[Route("[controller]")]
public class ProducerController : ControllerBase
{
    private ProducerConfig _config;

    private const string LocalBootstrapServers = "localhost:9092";

    private const string DockerBootstrapServers = "kafka:9092";

    private const string Topic = "testtopic";

    private readonly ILogger<ProducerController> _logger;

    public ProducerController(ILogger<ProducerController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _logger.LogInformation($"Constructing {nameof(ProducerController)}");
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrderRequest orderRequest)
    {
        var message = JsonSerializer.Serialize(orderRequest);

        return Ok(await SendOrderRequest(Topic, message));
    }

    private async Task<bool> SendOrderRequest
        (string topic, string message)
    {
        _config = new ProducerConfig
        {
            BootstrapServers = LocalBootstrapServers,
            EnableDeliveryReports = true,
            ClientId = Dns.GetHostName(),
            Debug = "msg",
            // retry settings:
            Acks = Acks.All,
            MessageSendMaxRetries = 3,
            RetryBackoffMs = 1000,
            EnableIdempotence = true
        };

        try
        {
            using var producer = new ProducerBuilder<Null, string>(_config)
                .SetLogHandler((_, logMessage) =>
                    Console.WriteLine(
                        $"Facility: {logMessage.Facility}-{logMessage.Level} Message: {logMessage.Message}"))
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}. Is Fatal: {e.IsFatal}"))
                .Build();

            var result = await producer.ProduceAsync(topic, new Message<Null, string>
            {
                Value = message
            });

            _logger.LogInformation(
                "{ProducerControllerName}.{SendOrderRequestName}: Delivered {ResultMessage} to topic {ResultTopic} in partition {ResultPartition} at Timestamp {TimestampUtcDateTime}",
                nameof(ProducerController), nameof(SendOrderRequest), result.Message.Value, result.Topic,
                result.Partition,
                result.Timestamp.UtcDateTime);

            if (result.Status != PersistenceStatus.Persisted)
            {
                // delivery might have failed after retries. This message requires manual processing.
                _logger.LogWarning(
                    "ERROR: Message not ack\'d by all brokers (value: \'{Message}\'). Delivery status: {ResultStatus}",
                    message, result.Status);
            }

            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured: {ExMessage}", ex.Message);
        }

        return await Task.FromResult(false);
    }
}