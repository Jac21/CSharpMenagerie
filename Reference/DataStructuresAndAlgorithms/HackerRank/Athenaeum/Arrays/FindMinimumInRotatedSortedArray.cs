using System.Linq;

namespace Athenaeum.Arrays
{
    public static class FindMinimumInRotatedSortedArray
    {
        public static int FindMin(int[] nums)
        {
            switch (nums.Length)
            {
                case 0:
                    return 0;
                case 1:
                    return nums.FirstOrDefault();
            }

            var low = 0;
            var high = nums.Length - 1;

            while (low < high)
            {
                var mid = low + (high - low) / 2;

                if (nums[low] < nums[high]) return nums[low];

                if (nums[mid] >= nums[low])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            return nums[low];
        }
    }
}