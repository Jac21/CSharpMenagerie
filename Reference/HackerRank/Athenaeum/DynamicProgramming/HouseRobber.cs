using System;

namespace Athenaeum.DynamicProgramming
{
    public static class HouseRobber
    {
        public static int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var next = 0;
            var previous = 0;
            var current = 0;

            foreach (var num in nums)
            {
                next = Math.Max(previous + num, current);

                previous = current;

                current = next;
            }

            return next;
        }
    }
}