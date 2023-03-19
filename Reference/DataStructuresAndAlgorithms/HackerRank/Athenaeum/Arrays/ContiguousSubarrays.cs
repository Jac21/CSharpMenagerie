using System;
using System.Linq;

namespace Athenaeum.Arrays
{
    public static class ContiguousSubarrays
    {
        public static int[] CountSubarrays(int[] arr)
        {
            if (!arr.Any()) return Array.Empty<int>();

            if (arr.Length == 1) return new[] {arr[0]};

            var contiguousSubarray = new int[arr.Length];
            var currentMax = 0;

            for (var i = 0; i < arr.Length; i++)
            {
                // base case
                if (i is 0)
                {
                    contiguousSubarray[i] = 1;
                }
                else
                {
                    var entry = arr[i];

                    var entriesLeftOfIndex =
                        arr.Take(arr[i] - 1);

                    var entriesLessThanIndex =
                        entriesLeftOfIndex.Where(x => x < entry);

                    var count = Math.Max(1, entriesLessThanIndex.Count());

                    if (currentMax < entry)
                    {
                        currentMax = entry;
                        count += 1;
                    }

                    contiguousSubarray[i] = count;
                }
            }

            return contiguousSubarray;
        }
    }
}