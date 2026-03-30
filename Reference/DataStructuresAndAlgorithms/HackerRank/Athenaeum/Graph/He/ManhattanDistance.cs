using System;
using System.Numerics;

// Required for BigInteger

namespace Athenaeum.Graph.He
{
    public class ManhattanDistance
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for(var t = 0; t < testCaseCount; t++) {
                var n = Convert.ToInt32(Console.ReadLine());

                var xCoordinates = new long[n];
                var yCoordinates = new long[n];

                for(var i = 0; i < n; i++) {
                    var towns = Console.ReadLine().Split();

                    xCoordinates[i] = Convert.ToInt64(towns[0]);
                    yCoordinates[i] = Convert.ToInt64(towns[1]);
                }

                Array.Sort(xCoordinates);
                Array.Sort(yCoordinates);

                BigInteger totalSum = 0;
                totalSum += CalculateContribution(n, xCoordinates);
                totalSum += CalculateContribution(n, yCoordinates);

                Console.WriteLine(totalSum);
            }
        }

        private static BigInteger CalculateContribution(int n, long[] coordinates)
        {
            if (n == 0) return 0;

            BigInteger sum = 0;

            for(var i = 0; i < n; i++) {
                // Formula: coord * (count_of_smaller - count_of_larger)
                // (i) is count of elements before it, (n - 1 - i) is count after it
                long multiplier = (long)i - (n - 1 - i);
                sum += (BigInteger)coordinates[i] * multiplier;
            }
			
            return sum;
        }
    }
}