using System;
using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array
{
    public class CandyDistributorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CandyDistributor_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = CandyDistributor.DistributeCandies(new[] { 1, 1, 2, 2, 3, 3 });

            // assert
            Assert.AreEqual(simpleCase, 3);
        }

        [Test]
        public void CandyDistributor_SimpleCaseTwo_Success()
        {
            // arrange

            // act
            var simpleCase = CandyDistributor.DistributeCandies(new[] { 1, 1, 2, 3 });

            // assert
            Assert.AreEqual(simpleCase, 2);
        }

        [Test]
        public void CandyDistributor_SimpleCaseThree_Success()
        {
            // arrange

            // act
            var simpleCase = CandyDistributor.DistributeCandies(new[] { 6, 6, 6, 6 });

            // assert
            Assert.AreEqual(simpleCase, 1);
        }
    }
}
