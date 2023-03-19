using System;
using System.Linq;

namespace Athenaeum.Algorithms
{
    public static class TentativeTestTwo
    {
        public static int[] solution(int[] A, int F, int M)
        {
            // sanity checks
            if (!A.Any()) return new[] {0};

            // create results array with a length of the missing rolls
            var result = new int[F];

            // derive total roll value
            var rollsSum = A.Sum();

            // derive aggregated totals, missing value from total
            var total = M * (A.Length + F);
            var remainder = total - rollsSum;
            
            // additional validity checks/unsolvable cases
            var remainingRolls = remainder / F;
            var totalRemainder = remainder % F;

            if (remainingRolls > 6 ||
                (remainingRolls == 6 &&
                 totalRemainder > 0))
            {
                return new[] {0};
            }

            // derive missing roll entries
            // TODO - Derive exact values, use 6 as placeholder for maximum potential value
            for (var i = 0; i < F; i++)
            {
                if (remainder < 0)
                {
                    break;
                }

                result[i] += 6;
                remainder -= 6;
            }

            return result;
        }
    }
}