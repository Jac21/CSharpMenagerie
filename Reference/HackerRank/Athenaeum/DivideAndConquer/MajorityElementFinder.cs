using System;
using System.Linq;

namespace Athenaeum.DivideAndConquer
{
    public static class MajorityElementFinder
    {
        public static int MajorityElement(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var result = nums
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .FirstOrDefault();

            return result;
        }
    }
}