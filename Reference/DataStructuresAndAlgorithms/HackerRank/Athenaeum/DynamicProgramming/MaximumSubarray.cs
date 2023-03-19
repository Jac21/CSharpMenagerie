using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.DynamicProgramming
{
    public static class MaximumSubarray
    {
        /// <summary>
        /// Kadane's Algorithm, O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaxSubArray(int[] nums)
        {
            if (!nums.Any()) return 0;

            if (nums.Length == 1) return nums.FirstOrDefault();

            var largestSum = int.MinValue;

            var currentSum = 0;

            foreach (var num in nums)
            {
                currentSum += num;

                largestSum = Math.Max(largestSum, currentSum);

                currentSum = Math.Max(0, currentSum);
            }

            return largestSum;
        }

        public static int MaxSubArrayDivideAndConquer(int[] nums)
        {
            return DivideAndConquerHelper(nums, 0, nums.Length - 1);
        }

        private static int DivideAndConquerHelper(IReadOnlyList<int> nums, int i, int numsLength)
        {
            if (i == numsLength) return nums[i];

            var mid = (i + numsLength) / 2;
            int sum = 0, leftMax = int.MinValue, rightMax = int.MinValue;

            for (var l = mid; l >= i; l--)
            {
                sum += nums[l];

                leftMax = Math.Max(sum, leftMax);
            }

            sum = 0;

            for (var l = mid + 1; l <= numsLength; l++)
            {
                sum += nums[l];

                rightMax = Math.Max(sum, rightMax);
            }

            var maxLeftRight = Math.Max(DivideAndConquerHelper(nums, i, mid),
                DivideAndConquerHelper(nums, mid + 1, numsLength));

            return Math.Max(maxLeftRight, leftMax + rightMax);
        }
    }
}