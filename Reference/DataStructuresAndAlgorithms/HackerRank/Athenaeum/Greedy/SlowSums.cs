using System;

namespace Athenaeum.Greedy
{
    public static class SlowSums
    {
        public static int GetTotalTime(int[] arr)
        {
            if (arr.Length == 0) return 0;

            var penalty = 0;
            var length = arr.Length;

            // O(n)
            Array.Sort(arr);
            
            while (length > 1)
            {
                var sum = arr[^1] + arr[^2];

                penalty += sum;

                var slice = arr[..^2];

                arr = new int[length - 1];

                // O(j)
                for (var j = 0; j < slice.Length; j++)
                {
                    arr[j] = slice[j];
                }

                arr[^1] = sum;

                length = arr.Length;
            }

            return penalty;
        }
    }
}