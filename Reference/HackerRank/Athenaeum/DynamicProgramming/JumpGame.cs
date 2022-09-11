using System.Linq;

namespace Athenaeum.DynamicProgramming
{
    public static class JumpGame
    {
        public static bool CanJump(int[] nums)
        {
            // set goal as the end of the array/level
            var goal = nums.Length - 1;

            // work backwards from goal
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                // if we can jump, continually set goal
                if (nums[i] + i >= goal)
                {
                    goal = i;
                }
            }

            return goal == 0;
        }
    }
}