using System;
using System.Linq;

namespace Athenaeum.Arrays
{
    public static class MaximumSubarray
    {
        public static int MaxSubArray(int[] nums)
        {
            switch (nums.Length)
            {
                case 0:
                    return 0;
                case 1:
                    return nums.FirstOrDefault();
            }

            var result = int.MinValue;

            var currentSum = 0;

            foreach (var num in nums)
            {
                currentSum += num;

                result = Math.Max(result, currentSum);

                currentSum = Math.Max(0, currentSum);
            }

            return result;
        }
    }
}