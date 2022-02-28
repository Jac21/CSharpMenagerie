using System;
using System.Linq;

namespace Athenaeum.Greedy
{
    public static class LargestNumberFinder
    {
        public static string LargestNumber(int[] nums)
        {
            if (nums.Length == 0) return string.Empty;

            if (nums.All(x => x == 0)) return "0";

            var sortedNumsStringList = nums
                .Select(x => x.ToString())
                .ToList();

            sortedNumsStringList.Sort((x, y) => -(x + y).CompareTo(y + x));

            var result = string.Join(string.Empty, sortedNumsStringList);

            return result;
        }
    }
}