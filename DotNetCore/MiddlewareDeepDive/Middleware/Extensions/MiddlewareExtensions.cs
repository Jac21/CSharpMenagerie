namespace MiddlewareDeepDive.Middleware.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseSimpleResponseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SimpleResponseMiddleware>();
    }

    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggingMiddleware>();
    }
    
    public static IApplicationBuilder UseIntentionalDelayMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<IntentionalDelayMiddleware>();
    }
    
    public static IApplicationBuilder UseTimeLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeLoggingMiddleware>();
    }
}