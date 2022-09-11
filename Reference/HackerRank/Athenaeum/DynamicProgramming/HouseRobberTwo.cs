using System;
using System.Linq;

namespace Athenaeum.DynamicProgramming
{
    public static class HouseRobberTwo
    {
        public static int Rob(int[] nums)
        {
            return Math.Max(
                Rob(nums, 0, nums.Length - 1),
                Rob(nums, 1, nums.Length)
            );
        }

        private static int Rob(int[] nums, int start, int end)
        {
            switch (nums.Length)
            {
                case 0:
                    return 0;
                case 1:
                    return nums.FirstOrDefault();
            }

            var firstPrevious = 0;
            var current = 0;

            for (var i = start; i < end; i++)
            {
                var secondPrevious = firstPrevious;
                firstPrevious = current;
                current = Math.Max(firstPrevious, secondPrevious + nums[i]);
            }

            return current;
        }
    }
}