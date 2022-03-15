using System;
using System.Linq;

namespace Athenaeum.Heaps
{
    public static class MedianStream
    {
        public static int[] FindMedian(int[] arr)
        {
            if (arr.Length == 0) return Array.Empty<int>();

            var output = new int[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                var stream = arr
                    .Take(i + 1)
                    .ToList();

                stream.Sort();

                if (stream.Count % 2 == 0)
                {
                    var leftMiddle = stream[stream.Count / 2 - 1];
                    var rightMiddle = stream[stream.Count / 2];

                    output[i] =
                        (int) Math.Floor((decimal) ((leftMiddle + rightMiddle) / 2));
                }
                else
                {
                    output[i] = stream[stream.Count / 2];
                }
            }

            return output;
        }
    }
}