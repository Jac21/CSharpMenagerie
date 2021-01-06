using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Leet
{
    public static class TwoSum
    {
        public static int[] FindTwoSumBruteForce(int[] nums, int target)
        {
            // base case
            if (nums.Length == 0)
            {
                return nums;
            }

            var indices = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        indices = new[] {i, j};
                    }
                }
            }

            return indices;
        }
    }

    public class TwoSumTests
    {
        [Test]
        public void TwoSum_FindTwoSumBruteForce_Success()
        {
            // arrange
            var nums = new[]
            {
                2, 7, 11, 15
            };

            var target = 9;

            // act
            var indices = TwoSum.FindTwoSumBruteForce(nums, target);

            // assert
            indices.Length.Should().Be(2);
            indices.FirstOrDefault().Should().Be(0);
            indices.Skip(1).FirstOrDefault().Should().Be(1);
        }
    }
}