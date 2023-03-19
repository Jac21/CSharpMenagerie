using System;

namespace Athenaeum.Greedy
{
    public static class FrequencyOfTheMostFrequentElement
    {
        public static int MaxFrequency(int[] nums, int k)
        {
            // sort so elements with the minimum difference are next to each other
            System.Array.Sort(nums);

            var result = 0;

            // sliding window bookends
            var left = 0;
            int right;

            long sum = 0;

            for (right = 0; right < nums.Length; ++right)
            {
                sum += nums[right];

                while (sum + k < (long) nums[right] * (right - left + 1))
                {
                    sum -= nums[left];
                    left += 1;
                }

                result = Math.Max(result, right - left + 1);
            }

            return result;
        }
    }
}