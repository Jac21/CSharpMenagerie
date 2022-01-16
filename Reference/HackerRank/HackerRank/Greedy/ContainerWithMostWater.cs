using System;

namespace HackerRank.Greedy
{
    public static class ContainerWithMostWater
    {
        public static int MaxArea(int[] height)
        {
            if (height.Length == 0) return 0;

            var max = 0;
            var left = 0;
            var right = height.Length - 1;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    var volume = height[left] * (right - left);

                    max = Math.Max(volume, max);

                    left += 1;
                }
                else
                {
                    var volume = height[right] * (right - left);

                    max = Math.Max(volume, max);

                    right -= 1;
                }
            }

            return max;
        }
    }
}