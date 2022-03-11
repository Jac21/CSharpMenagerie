using System;
using System.Collections.Generic;

namespace Athenaeum.Greedy
{
    public static class ElementSwapping
    {
        /// <summary>
        /// Greedy, iterative approach, O(n+n)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] FindMinArray(int[] arr, int k)
        {
            if (arr.Length == 0) return Array.Empty<int>();

            var result = new List<int>();

            while (k > 0)
            {
                var minimumIndex = 0;

                for (int i = 0; i < Math.Min(k + 1, arr.Length); i++)
                {
                    if (arr[i] < arr[minimumIndex])
                    {
                        minimumIndex = i;
                    }
                }

                // move this element to the front
                k -= minimumIndex;
                result.Add(arr[minimumIndex]);

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != minimumIndex)
                    {
                        result.Add(arr[i]);
                    }
                }
            }

            return result.ToArray();
        }
    }
}