using Athenaeum.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms
{

    public class RevenueMilestonesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RevenueMilestones_SimpleCase_Success()
        {
            // arrange
            var revenues = new[]
            {
            10, 20, 30, 40, 50, 60, 70, 80, 90, 100
        };

            var milestones = new[]
            {
            100, 200, 500
        };

            // act
            var result = RevenueMilestones.GetMilestoneDaysIterative(revenues, milestones);

            // assert
            Assert.AreEqual(new[] { 4, 6, 10 }, result);
        }
    }
}