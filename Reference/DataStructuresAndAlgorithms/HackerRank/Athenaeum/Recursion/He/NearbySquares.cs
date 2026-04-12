using System;
using System.Linq;
using System.Numerics;

// Required for BigInteger to handle (Sum^2)

namespace Athenaeum.Recursion.He
{
    public class NearbySquares
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            if (string.IsNullOrEmpty(line)) return;
            var T = Convert.ToInt32(line);

            for (var t_i = 0; t_i < T; t_i++)
            {
                var N = Convert.ToInt32(Console.ReadLine());
                var A = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                Console.WriteLine(Solution(N, A));
            }
        }

        private static string Solution(int N, long[] A)
        {
            var totalSum = A.Sum();

            // recurse to find best possible sum for group B
            var bestSumB = FindBestSumB(0, 0, totalSum, A);

            var sumC = totalSum - bestSumB;

            // using BigInt to calculate |Sb^2 - Sc^2| without overflow
            var b = new BigInteger(bestSumB);
            var c = new BigInteger(sumC);
            var diff = BigInteger.Abs((b * b) - (c * c));

            return diff.ToString();
        }

        private static long FindBestSumB(int index, long currentSumB, long totalSum, long[] A)
        {
            // base case
            if (index == A.Length) return currentSumB;

            // branch 1 - include A[index] in Group B
            var sumWith = FindBestSumB(index + 1, currentSumB + A[index], totalSum, A);

            // branch 2 - exclude A{index} from Group B (it's now in Group C)
            var sumWithout = FindBestSumB(index + 1, currentSumB, totalSum, A);

            // return whichever result's total diff is smaller
            var target = totalSum / 2.0;

            return Math.Abs(sumWith - target) < Math.Abs(sumWithout - target) ? sumWith : sumWithout;
        }
    }
}