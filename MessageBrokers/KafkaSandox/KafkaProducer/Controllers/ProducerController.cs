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
    private const string BootstrapServers = "localhost:9092";

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
            BootstrapServers = BootstrapServers,
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
                "{ProducerControllerName}.{SendOrderRequestName}: Delivery Timestamp - {TimestampUtcDateTime}",
                nameof(ProducerController), nameof(SendOrderRequest), result.Timestamp.UtcDateTime);

            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured: {ExMessage}", ex.Message);
        }

        return await Task.FromResult(false);
    }
}