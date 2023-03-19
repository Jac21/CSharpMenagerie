using System.Diagnostics;
using MiddlewareDeepDive.Logging.Interfaces;

namespace MiddlewareDeepDive.Middleware;

public class TimeLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggingService _logger;

    public TimeLoggingMiddleware(RequestDelegate next,
        ILoggingService logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var watch = Stopwatch.StartNew();

        await _next(context);

        watch.Stop();

        _logger.Log(LogLevel.Information, $"Time to execute: {watch.ElapsedMilliseconds} milliseconds.");
    }
}