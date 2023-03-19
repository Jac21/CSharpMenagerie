using System;
using System.Linq;

namespace Athenaeum.Sorting
{
    public static class BalancedSplit
    {
        public static bool BalancedSplitExistsIterative(int[] arr)
        {
            if (arr.Length == 0) return false;

            // sort in ascending order, O(nlogn)
            Array.Sort(arr);

            for (var i = 0; i < arr.Length; i++)
            {
                var leftIndicesInclusive = arr.Take(i + 1);

                var rightIndicesInclusive = arr.Skip(i + 1).Take(arr.Length - i - 1);

                var leftSum = leftIndicesInclusive.Sum();

                var rightSum = rightIndicesInclusive.Sum();

                if (leftSum == rightSum &&
                    !leftIndicesInclusive.Any(x => rightIndicesInclusive.Any(y => x >= y)))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool BalancedSplitExistsLessIterative(int[] arr)
        {
            if (arr.Length == 0) return false;

            // sort in ascending order, O(nlogn)
            Array.Sort(arr);

            var leftSum = arr.Sum();
            var rightSum = 0;

            for (var i = arr.Length - 1; i >= 0; i--)
            {
                leftSum -= arr[i];
                rightSum += arr[i];

                if (leftSum == rightSum)
                {
                    if (arr[i - 1] < arr[i])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}