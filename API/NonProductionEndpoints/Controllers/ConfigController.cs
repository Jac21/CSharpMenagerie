using Microsoft.AspNetCore.Mvc;
using NonProductionEndpoints.Filters;

namespace NonProductionEndpoints.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigController : ControllerBase
{
    private readonly IConfiguration configuration;

    public ConfigController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    
    [HttpGet("config")]
    [NonProduction]
    public IActionResult Config()
    {
        return Ok(configuration.GetChildren().Select(c => new { c.Key, c.Value }));
    }
}