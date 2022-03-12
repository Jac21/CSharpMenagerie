using System;

namespace Athenaeum.Greedy
{
    public static class SeatingArrangements
    {
        public static int MinOverallAwkwardness(int[] arr)
        {
            if (arr.Length == 0) return 0;

            Array.Sort(arr);

            var awk = 0;

            for (var i = 0; i < arr.Length - 2; i++)
            {
                var temp = arr[i + 2] - arr[i];
                awk = Math.Max(awk, temp);
            }

            return awk;
        }
    }
}