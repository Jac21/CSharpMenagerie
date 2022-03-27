using System;
using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming
{
    public class CoinChangeTests
    {
        public void Setup()
        {
        }

        [Test]
        public void CoinChange_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = CoinChange.MakeCoinChange(new[] { 1, 2, 5 }, 11);

            // assert
            Assert.AreEqual(3, simpleCase);
        }

        [Test]
        public void CoinChange_SimpleCaseTwo_Success()
        {
            // arrange

            // act
            var simpleCase = CoinChange.MakeCoinChange(new[] { 2 }, 3);

            // assert
            Assert.AreEqual(-1, simpleCase);
        }

        [Test]
        public void CoinChange_SimpleCaseThree_Success()
        {
            // arrange

            // act
            var simpleCase = CoinChange.MakeCoinChange(new[] { 1 }, 0);

            // assert
            Assert.AreEqual(0, simpleCase);
        }
    }
}
