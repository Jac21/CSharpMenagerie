using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using MvcFilters.Filters;

namespace MvcFilters.Controllers
{
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

        [HttpGet]
        [ServiceFilter(typeof(AuthorizeIpAddress))]
        [ServiceFilter(typeof(CacheResourceFilter))]
        [ServiceFilter(typeof(TimeTaken))]
        [ServiceFilter(typeof(AddResultFilter))]
        public WeatherForecast Get()
        {
            var rng = new Random();

            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(rng.Next(1, 30)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }
    }
}