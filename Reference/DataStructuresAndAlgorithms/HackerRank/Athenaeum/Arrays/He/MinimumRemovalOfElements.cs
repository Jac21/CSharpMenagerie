using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    public class MinimumRemovalOfElements
    {
        private const int MaxVal = 1_000_001;

        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var n = Convert.ToInt32(Console.ReadLine());

                var a = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var result = Solve(n, a);

                Console.WriteLine(result);
            }
        }

        private static int Solve(int n, int[] a)
        {
            if (n == 0) return 0;

            // derive frequency of numbers up to constraint
            var freq = new int[MaxVal];
            foreach (var x in a)
            {
                freq[x] += 1;
            }

            var maxKept = 0;
            var visited = new bool[MaxVal];
            for (int i = 2; i < MaxVal; i++)
            {
                if (!visited[i]) // If 'i' hasn't been crossed out, it's a prime!
                {
                    int currentKept = 0;
                    // Jump through all multiples of this prime: P, 2P, 3P...
                    for (int j = i; j < MaxVal; j += i)
                    {
                        visited[j] = true; // Mark multiples so we don't re-check them
                        currentKept += freq[j]; // Add the count of this multiple
                    }

                    maxKept = Math.Max(maxKept, currentKept);
                }
            }

            if (maxKept == 0) return -1;

            return n - maxKept;
        }
    }
}