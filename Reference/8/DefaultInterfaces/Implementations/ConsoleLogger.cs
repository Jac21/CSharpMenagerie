using System;
using _8.DefaultInterfaces.Interfaces;

namespace _8.DefaultInterfaces.Implementations
{
    public class ConsoleLogger : ILogger
    {
        public void WriteCore(LogLevel level, string message)
        {
            Console.WriteLine($"{level}: {message}");
        }
    }
}