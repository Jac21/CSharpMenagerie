using System.Linq;

namespace Athenaeum.Arrays
{
    public static class SearchInRotatedSortedArray
    {
        public static int Search(int[] nums, int target)
        {
            if (nums.Length == 0 ||
                (nums.Length == 1 &&
                 nums.FirstOrDefault() == target))
            {
                return 0;
            }

            var low = 0;
            var high = nums.Length - 1;

            while (low <= high)
            {
                var mid = (low+high) / 2;

                if (nums[mid] == target) return mid;

                if (nums[mid] <= nums[high])
                {
                    if (target > nums[mid] && target <= nums[high])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                else
                {
                    if (target >= nums[low] && target < nums[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
            }

            return -1;
        }
    }
}