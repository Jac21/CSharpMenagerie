using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.DivideAndConquer
{
    public static class TopKFrequentElements
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            var resultsDictionary = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!resultsDictionary.ContainsKey(num))
                {
                    resultsDictionary.Add(num, 1);
                }
                else
                {
                    resultsDictionary[num] += 1;
                }
            }

            return resultsDictionary
                .OrderByDescending(kvp => kvp.Value)
                .Take(k)
                .Select(x => x.Key)
                .ToArray();
        }
    }
}