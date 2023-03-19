using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming
{
    public class LongestIncreasingSubsequenceTests
    {
        public void Setup()
        {
        }

        [Test]
        public void LongestIncreasingSubsequence_SimpleCase_Success()
        {
            // arrange
            var nums = new[] { 10, 9, 2, 5, 3, 7, 101, 18 };

            // act
            var simpleCase = LongestIncreasingSubsequence.LengthOfLIS(nums);

            // assert
            Assert.AreEqual(4, simpleCase);
        }

        [Test]
        public void LongestIncreasingSubsequence_SimpleCaseTwo_Success()
        {
            // arrange
            var nums = new[] { 0, 1, 0, 3, 2, 3 };

            // act
            var simpleCase = LongestIncreasingSubsequence.LengthOfLIS(nums);

            // assert
            Assert.AreEqual(4, simpleCase);
        }

        [Test]
        public void LongestIncreasingSubsequence_SimpleCaseThree_Success()
        {
            // arrange
            var nums = new[] { 7, 7, 7, 7, 7, 7, 7 };

            // act
            var simpleCase = LongestIncreasingSubsequence.LengthOfLIS(nums);

            // assert
            Assert.AreEqual(1, simpleCase);
        }
    }
}
