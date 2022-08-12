using MiddlewareDeepDive.Logging.Interfaces;

namespace MiddlewareDeepDive.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggingService _logger;

    public LoggingMiddleware(RequestDelegate next, ILoggingService logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));

        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.Log(LogLevel.Information, context.Request.Path);

        await _next(context);

        var uniqueResponseHeaders = context.Response.Headers.Select(x => x.Key).Distinct();

        _logger.Log(LogLevel.Information, string.Join(",", uniqueResponseHeaders));
    }
}