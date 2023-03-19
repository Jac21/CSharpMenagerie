using Microsoft.AspNetCore.Mvc;

namespace DistributedTracing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracerController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TracerController> _logger;

        public TracerController(HttpClient httpClient, ILogger<TracerController> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/Tracer
        [HttpGet]
        public Task<string> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation(2001, "WebApp API request forwarded");

            return _httpClient.GetStringAsync("https://localhost:7182/Home", cancellationToken);
        }

        // GET: api/Tracer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tracer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Tracer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Tracer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}