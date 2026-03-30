using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    public class CountingSquareSubmatrices
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var n = Convert.ToInt32(input[0]);
            var m = Convert.ToInt32(input[1]);
            var x = Convert.ToInt64(input[2]);

            var matrix = new long[n + 1, m + 1];
            var prefixSum = new long[n + 1, m + 1];

            for (var i = 1; i <= n; i++)
            {
                var row = Console.ReadLine().Split();

                for (var j = 1; j <= m; j++)
                {
                    matrix[i, j] = long.Parse(row[j - 1]);

                    // build prefix sum table
                    prefixSum[i, j] = matrix[i, j] + prefixSum[i - 1, j] + prefixSum[i, j - 1] -
                                      prefixSum[i - 1, j - 1];
                }
            }

            var count = 0L;

            // try every possible top left corner (i, j)
            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= m; j++)
                {
                    // try every possible side length L for a square
                    for (int L = 1; i + L - 1 <= n && j + L - 1 <= m; L++)
                    {
                        var r2 = i + L - 1;
                        var c2 = j + L - 1;

                        // submatrix sum
                        var currentSum = prefixSum[r2, c2] - prefixSum[i - 1, c2] - prefixSum[r2, j - 1] +
                                         prefixSum[i - 1, j - 1];

                        if (currentSum >= x)
                        {
                            count += 1;
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}