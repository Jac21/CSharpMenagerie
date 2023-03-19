using System;

namespace Athenaeum.Arrays
{
    public static class NextPermutationFinder
    {
        public static void NextPermutation(int[] nums)
        {
            if (nums.Length == 0) return;

            var i = nums.Length - 2;

            while (i >= 0 &&
                   nums[i] >= nums[i + 1])
            {
                i -= 1;
            }

            if (i >= 0)
            {
                var j = nums.Length - 1;

                while (nums[i] >= nums[j])
                {
                    j -= 1;
                }

                (nums[i], nums[j]) = (nums[j], nums[i]);
            }

            nums.AsSpan(i + 1, nums.Length - i - 1).Reverse();
        }
    }
}