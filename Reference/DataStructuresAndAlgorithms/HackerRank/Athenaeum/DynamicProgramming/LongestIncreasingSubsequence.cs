using System;
using System.Linq;

namespace Athenaeum.DynamicProgramming
{
    /// <summary>
    /// Time: O(n^2)
    /// Space: O(n)
    /// </summary>
    public static class LongestIncreasingSubsequence
    {
        public static int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var dpArray = new int[nums.Length];
            Array.Fill(dpArray, 1);

            for (var i = 1; i < nums.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dpArray[i] = Math.Max(dpArray[i], dpArray[j] + 1);
                    }
                }
            }

            return dpArray.Max();
        }
    }
}
