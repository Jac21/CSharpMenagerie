using System;
namespace Athenaeum.DynamicProgramming
{
    public class CoinChange
    {
        public static int MakeCoinChange(int[] coins, int amount)
        {
            if (coins.Length == 0 || amount == 0) return 0;

            // create inclusive array for full amount
            var dp = new int[amount + 1];

            Array.Fill(dp, -1);

            for (int i = 1; i <= amount; i++)
            {
                foreach (int coin in coins)
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
    }
}
