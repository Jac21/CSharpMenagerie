using Athenaeum.Greedy;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Greedy
{

    public class LargestNumberFinderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LargestNumberFinder_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = LargestNumberFinder.LargestNumber(new[] { 10, 2 });

            // assert
            Assert.AreEqual("210", simpleCase);
        }

        [Test]
        public void LargestNumberFinder_SimpleCaseTwo_Success()
        {
            // arrange

            // act
            var simpleCaseTwo = LargestNumberFinder.LargestNumber(new[] { 3, 30, 34, 5, 9 });

            // assert
            Assert.AreEqual("9534330", simpleCaseTwo);
        }
    }
}