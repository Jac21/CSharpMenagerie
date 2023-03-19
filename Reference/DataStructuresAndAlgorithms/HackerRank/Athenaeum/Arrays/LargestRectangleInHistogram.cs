using System;
using System.Collections.Generic;

namespace Athenaeum.Arrays
{
    public static class LargestRectangleInHistogram
    {
        public static int LargestRectangleArea(int[] heights)
        {
            if (heights.Length == 0)
            {
                return 0;
            }

            var maxArea = int.MinValue;
            var stack = new Stack<int>();

            for (var i = 0; i < heights.Length; i++)
            {
                var height = i == heights.Length ? 0 : heights[i];

                while (stack.Count > 0 &&
                       height < heights[stack.Peek()])
                {
                    var topHeight = heights[stack.Pop()];

                    var width = stack.Count > 0
                        ? i - 1 - stack.Peek()
                        : i;

                    maxArea = Math.Max(maxArea, topHeight * width);
                }

                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                var previousBar = stack.Pop();

                var area = (heights.Length - previousBar) * heights[previousBar];

                maxArea = Math.Max(area, maxArea);
            }

            return maxArea;
        }
    }
}