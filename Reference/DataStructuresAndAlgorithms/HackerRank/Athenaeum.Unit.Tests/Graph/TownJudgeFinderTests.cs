using Athenaeum.Graph;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Graph
{
    public class TownJudgeFinderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TownJudgeFinder_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = TownJudgeFinder.FindJudge(2, new[]
            {
            new[] {1, 2}
        });

            // assert
            Assert.Pass();
        }

        [Test]
        public void TownJudgeFinder_LargerCase_Success()
        {
            // arrange

            // act
            var largerCase = TownJudgeFinder.FindJudge(3, new[]
            {
            new[] {1, 3},
            new[] {2, 3}
        });

            // assert
            Assert.Pass();
        }

        [Test]
        public void TownJudgeFinder_VeryLargeCase_Success()
        {
            // arrange

            // act
            var veryLargeCase = TownJudgeFinder.FindJudge(4, new[]
            {
            new[] {1, 3},
            new[] {1, 4},
            new[] {2, 3},
            new[] {2, 4},
            new[] {4, 3},
        });

            // assert
            Assert.Pass();
        }

        [Test]
        public void TownJudgeFinder_NoJudge_Success()
        {
            // arrange

            // act
            var noJudgeCase = TownJudgeFinder.FindJudge(3, new[]
            {
            new[] {1, 3},
            new[] {2, 3},
            new[] {3, 1},
        });

            // assert
            Assert.Pass();
        }
    }
}