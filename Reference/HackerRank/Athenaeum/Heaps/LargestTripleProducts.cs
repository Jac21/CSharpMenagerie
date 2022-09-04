using System;
using System.Linq;
using System.Collections.Generic;

namespace Athenaeum.Heaps
{
    public static class LargestTripleProducts
    {
        public static int[] FindMaxProduct(int[] arr)
        {
            if (!arr.Any()) return Array.Empty<int>();

            if (arr.Length == 1) return new[] {-1};

            if (arr.Length == 2) return new[] {-1, -1};

            // results to return
            var computedArray = new int[arr.Length];

            // poor-man's priority queue
            var sortedArrayList = new List<int>
            {
                arr[0],
                arr[1],
                arr[2]
            };

            for (var i = 0; i < arr.Length; i++)
            {
                // base cases
                if (i is 0 or 1)
                {
                    computedArray[i] = -1;
                }
                // simply sum all three encountered values
                else if (i == 2)
                {
                    computedArray[i] = arr[i] * arr[i - 1] * arr[i - 2];
                }
                else
                {
                    // re-heap
                    sortedArrayList.Add(arr[i]);

                    sortedArrayList.Sort((a, b) => b.CompareTo(a));

                    computedArray[i] = sortedArrayList.FirstOrDefault() *
                                       sortedArrayList.Skip(1).FirstOrDefault() *
                                       sortedArrayList.Skip(2).FirstOrDefault();
                }
            }

            return computedArray;
        }
    }
}