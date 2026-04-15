using System;
using System.Linq;

namespace Athenaeum.Greedy.He
{
    public class OptimalDivision
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split();
            var n = Convert.ToInt32(inputLine[0]);
            var k = Convert.ToInt32(inputLine[1]);

            var a = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = Solve(n, k, a);

            Console.WriteLine(result);
        }

        private static int Solve(int n, int k, int[] a)
        {
            if (n < 2) return 0;


            // sort array in an ascending fashion
            Array.Sort(a);

            // set pointers
            var left = 0;
            var right = a.Length / 2;

            var maxOperations = 0;

            // slide pointers together until we find where k
            // can no longer be satisfied
            while (left < n / 2 && right < n)
            {
                if (a[right] - a[left] >= k)
                {
                    maxOperations += 1;

                    left += 1;
                    right += 1;
                }
                else
                {
                    right += 1;
                }
            }

            return maxOperations;
        }
    }
}