using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class TwoSum
    {
        public static int[] FindTwoSum(int[] nums, int target)
        {
            if (!nums.Any()) return new int[] { };

            if (nums.Length <= 2)
            {
                return new[] {0, 1};
            }

            var resultsDictionary = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (resultsDictionary.TryGetValue(target - nums[i], out var index))
                {
                    return new[] {index, i};
                }
                
                if (!resultsDictionary.ContainsKey(nums[i]))
                {
                    resultsDictionary.Add(nums[i], i);
                }
            }

            return new int[] { };
        }
    }
}