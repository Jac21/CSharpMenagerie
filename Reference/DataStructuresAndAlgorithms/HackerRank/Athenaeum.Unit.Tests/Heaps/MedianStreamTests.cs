using Athenaeum.Heaps;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Heaps
{
    public class MedianStreamTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MedianStream_SimpleCase_Success()
        {
            // arrange
            var input = new[]
            {
                5, 15, 1, 3
            };

            // act
            var result = MedianStream.FindMedian(input);

            // assert
            Assert.AreEqual(new[]
            {
                5, 10, 5, 4
            }, result);
        }

        [Test]
        public void MedianStream_SimpleCaseTwo_Success()
        {
            // arrange
            var input = new[]
            {
                1, 2
            };

            // act
            var result = MedianStream.FindMedian(input);

            // assert
            Assert.AreEqual(new[]
            {
                1, 1
            }, result);
        }
    }
}