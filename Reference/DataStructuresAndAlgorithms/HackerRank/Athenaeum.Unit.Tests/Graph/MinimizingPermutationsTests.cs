using Athenaeum.Graph;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Graph
{

    [Ignore("TODO")]
    public class MinimizingPermutationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MinimizingPermutations_SimpleCase_Success()
        {
            // arrange
            var input = new[]
            {
            3, 1, 2
        };

            // act
            var simpleCase = MinimizingPermutations.MinOperations(input);

            // assert
            Assert.AreEqual(2, simpleCase);
        }
    }
}