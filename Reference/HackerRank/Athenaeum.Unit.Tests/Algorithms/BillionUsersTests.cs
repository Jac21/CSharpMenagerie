using Athenaeum.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms
{
    public class BillionUsersTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RevenueMilestones_SimpleCase_Success()
        {
            // arrange
            var growthRates = new[]
            {
                1.5f
            };

            // act
            var result = BillionUsers.GetBillionUsersDayIterative(growthRates);

            // assert
            Assert.AreEqual(52, result);
        }

        [Test]
        public void RevenueMilestones_SimpleCaseTwo_Success()
        {
            // arrange
            var growthRates = new[]
            {
                1.1f, 1.2f, 1.3f
            };

            // act
            var result = BillionUsers.GetBillionUsersDayIterative(growthRates);

            // assert
            Assert.AreEqual(79, result);
        }

        [Test]
        public void RevenueMilestones_SimpleCaseThree_Success()
        {
            // arrange
            var growthRates = new[]
            {
                1.01f, 1.02f
            };

            // act
            var result = BillionUsers.GetBillionUsersDayIterative(growthRates);

            // assert
            Assert.AreEqual(1047, result);
        }

        [Test]
        public void RevenueMilestones_SimpleCaseBinary_Success()
        {
            // arrange
            var growthRates = new[]
            {
                1.5f
            };

            // act
            var result = BillionUsers.GetBillionUsersDayBinary(growthRates);

            // assert
            Assert.AreEqual(52, result);
        }

        [Test]
        public void RevenueMilestones_SimpleCaseTwoBinary_Success()
        {
            // arrange
            var growthRates = new[]
            {
                1.1f, 1.2f, 1.3f
            };

            // act
            var result = BillionUsers.GetBillionUsersDayBinary(growthRates);

            // assert
            Assert.AreEqual(79, result);
        }
    }
}