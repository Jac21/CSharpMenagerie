using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.DynamicProgramming
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

        public static int FindTwoSumCount(int[] arr, int k)
        {
            if (!arr.Any()) return 1;

            var count = 0;
            var resultsDictionary = new Dictionary<int, int>();

            for (var i = 0; i < arr.Length; i++)
            {
                if (resultsDictionary.TryGetValue(k - arr[i], out var index))
                {
                    count += 1;
                }

                if (!resultsDictionary.ContainsKey(arr[i]))
                {
                    resultsDictionary.Add(arr[i], i);
                }
            }

            return count;
        }
    }
}