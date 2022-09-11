using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Arrays
{
    public static class ThreeSumFinder
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            if (nums.Length == 0) return result;

            if (nums.Length == 3 && 
                nums.Sum() == 0)
            {
                return new List<IList<int>>
                {
                    nums.Take(3).ToList()
                };
            }

            Array.Sort(nums);

            for (var i = 0; i < nums.Length - 3; i++)
            {
                if (nums[i] > 0) break;

                var target = 0 - nums[i];

                if (i == 0 || nums[i] > nums[i - 1])
                {
                    var startIndex = i + 1;
                    var endIndex = nums.Length - 1;

                    while (startIndex < endIndex)
                    {
                        var sum = nums[startIndex] + nums[endIndex];

                        if (sum == target)
                        {
                            var valueOne = nums[startIndex];
                            var valueTwo = nums[endIndex];

                            result.Add(new List<int> {nums[i], valueOne, valueTwo});

                            while (startIndex < endIndex && valueOne == nums[startIndex])
                            {
                                startIndex += 1;
                            }

                            while (startIndex < endIndex && valueTwo == nums[endIndex - 1])
                            {
                                endIndex -= 1;
                            }
                        }
                        else if (sum < target)
                        {
                            startIndex += 1;
                        }
                        else
                        {
                            endIndex -= 1;
                        }
                    }
                }
            }

            return result;
        }
    }
}