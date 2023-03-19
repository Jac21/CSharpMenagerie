using System;

namespace Athenaeum.Arrays
{
    public static class ProductOfArrayExceptSelf
    {
        public static int[] ProductExceptSelf(int[] nums)
        {
            if (nums.Length == 0) return Array.Empty<int>();

            var result = new int[nums.Length];

            var left = 1;
            for (var i = 0; i < nums.Length; i++)
            {
                result[i] = left;
                left *= nums[i];
            }

            var right = 1;
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                result[i] *= right;
                right *= nums[i];
            }

            return result;
        }
    }
}