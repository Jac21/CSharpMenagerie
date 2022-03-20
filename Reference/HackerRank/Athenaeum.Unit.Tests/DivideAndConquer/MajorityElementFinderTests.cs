using Athenaeum.DivideAndConquer;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DivideAndConquer
{
    public class MajorityElementFinderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MajorityElementFinder_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = MajorityElementFinder.MajorityElement(new[] { 3, 2, 3 });

            // assert
            Assert.AreEqual(3, simpleCase);
        }

        [Test]
        public void MajorityElementFinder_SimpleCaseTwo_Success()
        {
            // arrange

            // act
            var simpleCaseTwo = MajorityElementFinder.MajorityElement(new[] { 2, 2, 1, 1, 1, 2, 2 });

            // assert
            Assert.AreEqual(2, simpleCaseTwo);
        }
    }
}