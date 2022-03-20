using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming
{

    public class TwoSumTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TwoSum_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = TwoSum.FindTwoSum(new[]
            {
            2, 7, 11, 15
        }, 9);

            // assert
            Assert.AreEqual(new[]
            {
            0, 1
        }, simpleCase);
        }

        [Test]
        public void TwoSum_SimpleCaseTwo_Success()
        {
            // arrange

            // act
            var simpleCaseTwo = TwoSum.FindTwoSum(new[]
            {
            3, 2, 4
        }, 6);

            // assert
            Assert.AreEqual(new[]
            {
            1, 2
        }, simpleCaseTwo);
        }

        [Test]
        public void TwoSum_BaseCase_Success()
        {
            // arrange

            // act
            var baseCase = TwoSum.FindTwoSum(new[]
            {
            3, 3
        }, 6);

            // assert
            Assert.AreEqual(new[]
            {
            0, 1
        }, baseCase);
        }

        [Test]
        public void TwoSumCount_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = TwoSum.FindTwoSumCount(new[]
            {
            1, 2, 3, 4, 3
        }, 6);

            // assert
            Assert.AreEqual(2, simpleCase);
        }
    }
}