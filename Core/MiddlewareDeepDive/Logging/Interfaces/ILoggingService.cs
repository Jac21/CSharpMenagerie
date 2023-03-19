namespace MiddlewareDeepDive.Logging.Interfaces;

public interface ILoggingService
{
    public void Log(LogLevel level, string message);
}