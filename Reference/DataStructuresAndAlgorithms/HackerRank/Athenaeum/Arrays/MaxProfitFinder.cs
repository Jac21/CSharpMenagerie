using System;
using System.Linq;

namespace Athenaeum.Arrays
{
    public class MaxProfitFinder
    {
        public static int MaxProfit(int[] prices)
        {
            if (!prices.Any()) return 0;

            var min = int.MaxValue;
            var max = int.MinValue;

            for (var i = 0; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                max = Math.Max(max, prices[i] - min);
            }

            return max;
        }
    }
}