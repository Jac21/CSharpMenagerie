using MiddlewareDeepDive.Logging.Interfaces;

namespace MiddlewareDeepDive.Logging.Implementations;

class LoggingService : ILoggingService
{
    public void Log(LogLevel level, string message)
    {
        Console.WriteLine(message);
    }
}