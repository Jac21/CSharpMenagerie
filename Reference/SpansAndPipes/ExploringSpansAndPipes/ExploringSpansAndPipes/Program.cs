using ExploringSpansAndPipes.Implementations;
using System;
using System.Threading.Tasks;

namespace ExploringSpansAndPipes
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Hello, Spans and Pipes!");

            FileParserSpansAndPipes fileParserSpansAndPipes = new FileParserSpansAndPipes();

            var videogame = await fileParserSpansAndPipes.Parse("file.txt.");
        }
    }
}