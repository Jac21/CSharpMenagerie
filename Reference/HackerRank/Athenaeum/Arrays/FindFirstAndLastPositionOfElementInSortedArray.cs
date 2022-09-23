using System.Collections.Generic;

namespace Athenaeum.Arrays
{
    public static class FindFirstAndLastPositionOfElementInSortedArray
    {
        public static int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0) return new[] {-1, -1};

            var first = BinarySearch(nums, target);

            if (nums[first] != target) return new[] {-1, -1};

            var right = BinarySearch(nums, target + 1);

            int last;

            if (nums[right] >= target + 1)
            {
                last = right - 1;
            }
            else
            {
                last = right;
            }

            return new[] {first, last};
        }

        private static int BinarySearch(IReadOnlyList<int> nums, int target)
        {
            var low = 0;
            var high = nums.Count - 1;

            while (low < high)
            {
                var mid = low + (high - low) / 2;

                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            return low;
        }
    }
}