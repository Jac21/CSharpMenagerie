using Athenaeum.Queues;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Queues
{
    public class QueueRemovalsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void QueueRemovals_SimpleCase_Success()
        {
            // arrange
            var arr = new[]
            {
                1, 2, 2, 3, 4, 5
            };

            var x = 5;

            // act
            var simpleCase = QueueRemovals.FindPositions(arr, x);

            // assert
            Assert.AreEqual(new[] { 5, 6, 4, 1, 2 }, simpleCase);
        }
    }
}
