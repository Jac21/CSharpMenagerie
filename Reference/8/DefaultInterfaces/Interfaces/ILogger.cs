namespace _8.DefaultInterfaces.Interfaces
{
    public interface ILogger
    {
        void WriteCore(LogLevel level, string message);

        void WriteInformation(string message)
        {
            WriteCore(LogLevel.Information, message);
        }

        void WriteWarning(string message)
        {
            WriteCore(LogLevel.Warning, message);
        }

        void WriteError(string message)
        {
            WriteCore(LogLevel.Error, message);
        }
    }
}