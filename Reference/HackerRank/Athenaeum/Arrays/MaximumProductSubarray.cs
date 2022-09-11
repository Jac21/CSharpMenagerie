using System;
using System.Linq;

namespace Athenaeum.Arrays
{
    public static class MaximumProductSubarray
    {
        public static int MaxProduct(int[] nums)
        {
            switch (nums.Length)
            {
                case 0:
                    return 0;
                case 1:
                    return nums.FirstOrDefault();
            }

            var firstEntry = nums.FirstOrDefault();

            var result = firstEntry;

            var currentMinimum = firstEntry;
            var currentMaximum = firstEntry;

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    (currentMaximum, currentMinimum) = (currentMinimum, currentMaximum);
                }

                currentMaximum = Math.Max(nums[i], currentMaximum * nums[i]);
                currentMinimum = Math.Min(nums[i], currentMinimum * nums[i]);

                result = Math.Max(result, currentMaximum);
            }

            return result;
        }
    }
}