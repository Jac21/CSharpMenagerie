using System;

namespace Athenaeum.DynamicProgramming
{
    public static class BestTimeToBuyAndSellStockFour
    {
        public static int MaxProfit(int k, int[] prices)
        {
            if (k == 0 ||
                prices.Length == 0)
            {
                return 0;
            }

            var maximumProfit = 0;

            var kBuy = new int[k];
            var kBuyKSell = new int[k];
            Array.Fill(kBuy, int.MinValue);

            for (var i = 0; i < prices.Length; i++)
            {
                kBuy[0] = Math.Max(kBuy[0], -prices[i]);
                kBuyKSell[0] = Math.Max(kBuyKSell[0], prices[i] + kBuy[0]);

                if (k > 1)
                {
                    for (var j = 1; j < k; j++)
                    {
                        kBuy[j] = Math.Max(kBuy[j], kBuyKSell[j - 1] - prices[i]);
                        kBuyKSell[j] = Math.Max(kBuyKSell[j], prices[i] + kBuy[j]);
                    }
                }
            }

            foreach (var item in kBuyKSell)
            {
                if (item > maximumProfit) maximumProfit = item;
            }

            return maximumProfit;
        }
    }
}