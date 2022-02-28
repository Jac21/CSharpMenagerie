using System.Linq;

namespace Athenaeum.Greedy
{
    public static class MaximizeSumArrayAfterKNegations
    {
        public static int LargestSumAfterKNegations(int[] nums, int k)
        {
            System.Array.Sort(nums);

            var index = 0;

            while (k != 0)
            {
                nums[index] *= -1;

                if (index + 1 < nums.Length &&
                    nums[index + 1] < nums[index])
                {
                    index += 1;
                }

                k--;
            }

            return nums.Sum();
        }
    }
}