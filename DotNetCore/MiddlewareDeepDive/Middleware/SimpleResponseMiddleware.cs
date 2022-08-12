namespace MiddlewareDeepDive.Middleware;

public class SimpleResponseMiddleware
{
    private readonly RequestDelegate _next;

    public SimpleResponseMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await context.Response.WriteAsync("Hello, Middleware!");

        await _next(context);
    }
}