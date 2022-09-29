using System;
using System.Collections.Generic;

namespace Athenaeum.Arrays
{
    public static class ShoppingOptions
    {
        public static int GetNumberOfOptions(int[] priceOfJeans, int[] priceOfShoes, int[] priceOfSkirts,
            int[] priceOfTops, int dollars)
        {
            if (dollars == 0) return 0;

            var count = 0;
            var shoppingOptions = new Dictionary<int, int>();

            foreach (var priceOfJean in priceOfJeans)
            {
                foreach (var priceOfTop in priceOfTops)
                {
                    var sum = priceOfJean + priceOfTop;

                    if (shoppingOptions.TryGetValue(sum, out var entry))
                    {
                        shoppingOptions[sum] = entry + 1;
                    }
                    else
                    {
                        shoppingOptions.Add(sum,1);
                    }
                }
            }

            foreach (var priceOfSkirt in priceOfSkirts)
            {
                foreach (var priceOfShoe in priceOfShoes)
                {
                    var sum = dollars - (priceOfSkirt + priceOfShoe);

                    foreach (var entry in shoppingOptions)
                    {
                        if (entry.Key <= sum)
                        {
                            count += entry.Value;
                        }
                    }
                }
            }

            return count;
        }
    }
}