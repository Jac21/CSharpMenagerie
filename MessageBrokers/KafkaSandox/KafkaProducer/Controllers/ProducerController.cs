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
        var config = new ProducerConfig
        {
            BootstrapServers = DockerBootstrapServers,
            ClientId = Dns.GetHostName()
        };

        try
        {
            using var producer = new ProducerBuilder<Null, string>(config).Build();

            var result = await producer.ProduceAsync(topic, new Message<Null, string>
            {
                Value = message
            });

            _logger.LogInformation(
                "{ProducerControllerName}.{SendOrderRequestName}: Delivered {ResultMessage} to topic {ResultTopic} in partition {ResultPartition} at Timestamp {TimestampUtcDateTime}",
                nameof(ProducerController), nameof(SendOrderRequest), result.Message.Value, result.Topic,
                result.Partition,
                result.Timestamp.UtcDateTime);

            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured: {ExMessage}", ex.Message);
        }

        return await Task.FromResult(false);
    }
}