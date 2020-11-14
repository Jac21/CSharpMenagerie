using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _8.AsynchronousStreams
{
    public class NamesStream
    {
        public async IAsyncEnumerable<string> GetNamesAsync()
        {
            string[] names =
            {
                "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato"
            };

            foreach (var name in names)
            {
                await Task.Delay(1000);
                yield return name;
            }
        }

        public async Task ConsumeStream()
        {
            await foreach (var name in GetNamesAsync())
            {
                Console.WriteLine(name);
            }
        }
    }
}