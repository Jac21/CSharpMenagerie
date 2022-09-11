using System;

namespace Athenaeum.Arrays
{
    public static class ContainerWithMostWater
    {
        public static int MaxArea(int[] height)
        {
            if (height.Length == 0) return 0;

            var maxArea = 0;
            var leftLine = 0;
            var rightLine = height.Length - 1;

            while (leftLine < rightLine)
            {
                if (height[leftLine] < height[rightLine])
                {
                    var volume = height[leftLine] * (rightLine - leftLine);

                    maxArea = Math.Max(maxArea, volume);

                    leftLine += 1;
                }
                else
                {
                    var volume = height[rightLine] * (rightLine - leftLine);

                    maxArea = Math.Max(maxArea, volume);

                    rightLine -= 1;
                }
            }

            return maxArea;
        }
    }
}