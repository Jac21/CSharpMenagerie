using Athenaeum.Heaps;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Heaps
{

    public class LargestTripleProductsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LargestTripleProducts_SimpleCase_Success()
        {
            // arrange
            var input = new[]
            {
            1, 2, 3, 4, 5
        };

            // act
            var result =
                LargestTripleProducts.FindMaxProduct(input);

            // assert
            Assert.AreEqual(new[]
            {
            -1, -1, 6, 24, 60
        }, result);
        }

        [Test]
        public void LargestTripleProducts_SimpleCaseTwo_Success()
        {
            // arrange
            var input = new[]
            {
            2, 1, 2, 1, 2
        };

            // act
            var result =
                LargestTripleProducts.FindMaxProduct(input);

            // assert
            Assert.AreEqual(new[]
            {
            -1, -1, 4, 4, 8
        }, result);
        }
    }
}