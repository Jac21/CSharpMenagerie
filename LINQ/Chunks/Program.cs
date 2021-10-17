using System;

namespace Chunks
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello Chunks!");

            var arr = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            var chunks = arr.Split(2);

            var i = 0;

            foreach (var chunk in chunks)
            {
                i += 1;

                Console.WriteLine($"Chunk {i}");

                foreach (var item in chunk)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}