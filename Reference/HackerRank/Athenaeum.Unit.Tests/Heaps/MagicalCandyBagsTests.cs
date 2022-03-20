using Athenaeum.Heaps;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Heaps
{

    public class MagicalCandyBagsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MagicalCandyBags_SimpleCase_Success()
        {
            // arrange
            var input = new[]
            {
            2, 1, 7, 4, 2
        };

            // act
            var result =
                MagicalCandyBags.MaxCandiesIterative(input, 3);

            // assert
            Assert.AreEqual(14, result);
        }

        [Test]
        public void MagicalCandyBags_SimpleCase_Heap_Success()
        {
            // arrange
            var input = new[]
            {
            2, 1, 7, 4, 2
        };

            // act
            var result =
                MagicalCandyBags.MaxCandiesHeap(input, 3);

            // assert
            Assert.AreEqual(14, result);
        }
    }
}