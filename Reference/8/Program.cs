using System;
using System.Threading.Tasks;
using _8.AsynchronousStreams;
using _8.DefaultInterfaces;
using _8.DefaultInterfaces.Implementations;
using _8.DefaultInterfaces.Interfaces;

namespace _8
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, C# 8.0!");

            // default interface methods
            ILogger consoleLogger = new ConsoleLogger();
            consoleLogger.WriteCore(LogLevel.Information, "Log!");

            ILogger traceLogger = new TraceLogger();
            traceLogger.WriteError("Error!");

            // asynchronous streams
            var asyncStreams = new AsyncStreamsExample();
            await asyncStreams.ConsumeStream();

            Console.ReadLine();
        }
    }
}