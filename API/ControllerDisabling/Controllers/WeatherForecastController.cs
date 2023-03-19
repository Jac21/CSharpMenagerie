using ControllerDisabling.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ControllerDisabling.Filters;

namespace ControllerDisabling.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation($"${nameof(WeatherForecastController)}: {nameof(Get)} called.");

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpPost(Name = "PostWeatherForecastDevelopmentEndpoint")]
    [AllowAnonymous]
    [DevelopmentOnly]
    public async Task<IActionResult> PostWeatherForecastDevelopmentEndpoint()
    {
        _logger.LogInformation($"${nameof(PostWeatherForecastDevelopmentEndpoint)}: {nameof(Get)} called.");

        await Task.Delay(1_000);

        return Ok();
    }
}