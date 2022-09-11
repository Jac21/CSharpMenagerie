using System;

namespace Athenaeum.DynamicProgramming
{
    public static class CombinationSumFour
    {
        public static int CombinationSum4(int[] nums, int target)
        {
            if (nums.Length == 0) return 0;

            var dp = new int[target + 1];
            dp[0] = 1;

            Array.Sort(nums);

            for (var i = 1; i <= target; i++)
            {
                for (var j = 0; j < nums.Length; j++)
                {
                    if (nums[j] <= i)
                    {
                        dp[i] += dp[i - nums[j]];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return dp[target];
        }
    }
}