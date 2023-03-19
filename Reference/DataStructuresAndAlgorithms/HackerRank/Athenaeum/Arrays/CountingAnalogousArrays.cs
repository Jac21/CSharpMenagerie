using System;

namespace Athenaeum.Arrays
{
    public static class CountingAnalogousArrays
    {
        public static int CountAnalogousArrays(int[] consecutiveDifferences, int lowerBound, int upperBound)
        {
            var count = 0;
            var min = lowerBound;
            var max = lowerBound;

            var previous = lowerBound;

            for (var i = 1; i <= consecutiveDifferences.Length; i++)
            {
                var current = previous - consecutiveDifferences[i - 1];
                max = Math.Max(max, current);
                min = Math.Min(min, current);
                previous = current;
            }

            while (max <= upperBound)
            {
                if (min >= lowerBound)
                {
                    count += 1;
                }

                min += 1;
                max += 1;
            }

            return count;
        }
    }
}