using Athenaeum.Recursion;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Recursion
{
    public class ForeignCurrencyTests

    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ForeignCurrency_SimpleCase_Success()
        {
            // arrange
            const int targetMoney = 94;

            var denominations = new[]
            {
                5,10,25,100,200
            };

            // act
            var simpleCase = ForeignCurrency.CanGetExactChange(targetMoney, denominations);

            // assert
            Assert.IsFalse(simpleCase);
        }

        [Test]
        public void ForeignCurrency_SimpleCaseTwo_Success()
        {
            // arrange
            const int targetMoney = 75;

            var denominations = new[]
            {
                4,17,29
            };

            // act
            var simpleCase = ForeignCurrency.CanGetExactChange(targetMoney, denominations);

            // assert
            Assert.IsTrue(simpleCase);
        }
    }
}