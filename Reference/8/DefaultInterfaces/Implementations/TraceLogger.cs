using System;
using System.Diagnostics;
using _8.DefaultInterfaces.Interfaces;

namespace _8.DefaultInterfaces.Implementations
{
    public class TraceLogger : ILogger
    {
        public void WriteCore(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Information:
                    Trace.TraceInformation(message);
                    break;

                case LogLevel.Warning:
                    Trace.TraceWarning(message);
                    break;

                case LogLevel.Error:
                    Trace.TraceError(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, "Argument ouf of range");
            }
        }
    }
}