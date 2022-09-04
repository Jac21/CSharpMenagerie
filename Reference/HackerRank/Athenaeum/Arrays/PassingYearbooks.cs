using System;

namespace Athenaeum.Arrays
{
    public static class PassingYearbooks
    {
        public static int[] FindSignatureCounts(int[] arr)
        {
            if (arr.Length == 0) return Array.Empty<int>();

            var output = new int[arr.Length];

            for (var i = 0; i < output.Length; i++)
            {
                output[i] = 1;
            }

            for (var i = 0; i < arr.Length; i++)
            {
                var k = i;

                while (arr[k] != i + 1)
                {
                    output[i] += 1;
                    k = arr[k] - 1;
                }
            }

            return output;
        }
    }
}