using JsonSourceGenerators.Entities;
using JsonSourceGenerators.SerializationContexts;
using Microsoft.AspNetCore.Mvc;

namespace JsonSourceGenerators.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet(Name = "GetPerson")]
    public IResult Get()
    {
        _logger.LogInformation($"{nameof(PersonController)}: Hit {nameof(Get)}");

        return Results.Json(new Person("Jeremy", Friend: new Person("Ymerej")),
            PersonSerializationContext.Default.Options);
    }
}