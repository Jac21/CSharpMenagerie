using System.Collections.Generic;
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

            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        indices = new[] {i, j};
                    }
                }
            }

            return indices;
        }

        public static int[] FindTwoSumDictionary(int[] nums, int target)
        {
            var indices = new int[2];
            var map = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                map.Add(nums[i], i);
            }

            for (var i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (map.TryGetValue(complement, out var index) && index != i)
                {
                    return new[] {i, index};
                }
            }

            return indices;
        }

        public static int[] FindTwoSumDictionaryOnePass(int[] nums, int target)
        {
            var indices = new int[2];
            var map = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (map.TryGetValue(complement, out var index))
                {
                    return new[] {index, i};
                }

                map.Add(nums[i], i);
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

            const int target = 9;

            // act
            var indices = TwoSum.FindTwoSumBruteForce(nums, target);

            // assert
            indices.Length.Should().Be(2);
            indices.FirstOrDefault().Should().Be(0);
            indices.Skip(1).FirstOrDefault().Should().Be(1);
        }

        [Test]
        public void TwoSum_FindTwoSumDictionary_Success()
        {
            // arrange
            var nums = new[]
            {
                2, 7, 11, 15
            };

            const int target = 9;

            // act
            var indices = TwoSum.FindTwoSumDictionary(nums, target);

            // assert
            indices.Length.Should().Be(2);
            indices.FirstOrDefault().Should().Be(0);
            indices.Skip(1).FirstOrDefault().Should().Be(1);
        }

        [Test]
        public void TwoSum_FindTwoSumDictionaryOnePass_Success()
        {
            // arrange
            var nums = new[]
            {
                2, 7, 11, 15
            };

            const int target = 9;

            // act
            var indices = TwoSum.FindTwoSumDictionaryOnePass(nums, target);

            // assert
            indices.Length.Should().Be(2);
            indices.FirstOrDefault().Should().Be(0);
            indices.Skip(1).FirstOrDefault().Should().Be(1);
        }
    }
}