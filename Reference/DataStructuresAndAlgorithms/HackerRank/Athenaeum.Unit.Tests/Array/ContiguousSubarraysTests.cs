using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array
{

    public class ContiguousSubarraysTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ContiguousSubarrays_SimpleCase_Success()
        {
            // arrange
            var input = new[]
            {
            3, 4, 1, 6, 2
        };

            // act
            var simpleCase = ContiguousSubarrays.CountSubarrays(input);

            // assert
            Assert.AreEqual(new[] { 1, 3, 1, 5, 1 }, simpleCase);
        }
    }
}