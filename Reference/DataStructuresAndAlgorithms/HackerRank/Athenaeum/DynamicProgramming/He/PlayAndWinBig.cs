using System;

namespace Athenaeum.DynamicProgramming.He
{
    public class PlayAndWinBig
    {
        private static int[,] _memo;

        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var count = Convert.ToInt32(Console.ReadLine());
                var coinValuesSplit = Console.ReadLine().Split(' ');

                // project values onto int array
                var coins = new int[count];
                for (var c = 0; c < count; c++)
                {
                    coins[c] = Convert.ToInt32(coinValuesSplit[c]);
                }

                _memo = new int[count, count];
                for (var j = 0; j < count; j++)
                {
                    for (var k = 0; k < count; k++)
                    {
                        _memo[j, k] = -1;
                    }
                }

                Console.WriteLine(Solve(coins, 0, count - 1));
            }
        }

        private static int Solve(int[] coins, int i, int j)
        {
            // base cases
            if (i > j) return 0;
            if (i == j) return coins[i];

            // return solved value
            if (_memo[i, j] != -1)
            {
                return _memo[i, j];
            }

            // left case
            var pickLeft = coins[i] + Math.Min(
                Solve(coins, i + 2, j),
                Solve(coins, i + 1, j - 1)
            );

            // right case
            var pickRight = coins[j] + Math.Min(
                Solve(coins, i + 1, j - 1),
                Solve(coins, i, j - 2)
            );

            _memo[i, j] = Math.Max(pickLeft, pickRight);

            return _memo[i, j];
        }
    }
}