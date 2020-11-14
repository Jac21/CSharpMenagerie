using System;
using System.Threading.Tasks;
using _8.AsynchronousStreams;
using _8.DefaultInterfaces;
using _8.DefaultInterfaces.Implementations;
using _8.DefaultInterfaces.Interfaces;
using _8.NullableReferenceTypes;

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
            var namesStream = new NamesStream();
            await namesStream.ConsumeStream();

            // nullable reference types
            const string shortDescrption = default; // Warning! non-nullable set to null;
            var securityDescription =
                new SecurityDescription(shortDescrption); // Warning! static analysis knows shortDescription maybe null.

            const string description = "ETF";
            var security = new SecurityDescription(description);

            security.SetDescriptions(description, "Exchange-Traded Fund");

            Console.ReadLine();
        }
    }
}