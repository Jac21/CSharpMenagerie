using System;

namespace Athenaeum.DynamicProgramming
{
    public static class CoinChange
    {
        public static int MakeCoinChange(int[] coins, int amount)
        {
            if (coins.Length == 0 || amount == 0) return 0;

            // create inclusive array for full amount
            var dp = new int[amount + 1];

            Array.Fill(dp, -1);

            for (var i = 1; i <= amount; i++)
            {
                foreach (var coin in coins)
                {
                    // if coin matches i, we only need
                    // one coin for that amount
                    if (coin == i)
                    {
                        dp[i] = 1;
                    }
                    // more likely case, coin is less than i
                    else if (coin < i)
                    {
                        // two cases:
                        // 1. dp[i] already has solution, and it's worse
                        // 2. dp[i] does not have a solution yet
                        if (dp[i - coin] != -1 &&
                            ((dp[i] != -1 && dp[i] > dp[i - coin] + 1)
                             || dp[i] == -1))
                        {
                            // set solution, take amount of coins, add one more coin
                            dp[i] = dp[i - coin] + 1;
                        }
                    }
                }
            }

            return dp[amount];
        }

        public static int MakeCoinChangeSecondSolution(int[] coins, int amount)
        {
            if (coins.Length == 0 || amount == 0) return 0;

            // create array to store number of coints required to exchange
            var d = new int[amount + 1];

            for (var i = 1; i <= amount; i++)
            {
                d[i] = int.MaxValue;

                for (var j = 0; j < coins.Length; j++)
                {
                    if (i >= coins[j] && d[i - coins[j]] != int.MaxValue)
                    {
                        d[i] = Math.Min(d[i], 1 + d[i - coins[j]]);
                    }
                }
            }

            return d[amount] == int.MaxValue ? -1 : d[amount];
        }
    }
}