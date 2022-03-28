using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array
{
    public class GameOfLifeBuilderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GameOfLifeBuilder_SimplerCase_Success()
        {
            // arrange
            var input = new int[][] {
                new[] { 1,1},
                new[] { 1,0},
            };

            var output = new int[][]
            {
                new[] {1,1},
                new[] {1,1}
            };

            // act
            var board = GameOfLifeBuilder.GameOfLife(input);

            // assert
            Assert.AreEqual(output, board);
        }

        [Test]
        public void GameOfLifeBuilder_SimpleCase_Success()
        {
            // arrange
            var input = new int[][] {
                new[] { 0,1,0},
                new[] { 0,0,1},
                new[] { 1,1,1},
                new[] { 0,0,0}
            };

            var output = new int[][] {
                new[] { 0,0,0},
                new[] { 1,0,1},
                new[] { 0,1,1},
                new[] { 0,1,0}
            };

            // act
            var board = GameOfLifeBuilder.GameOfLife(input);

            // assert
            Assert.AreEqual(output, board);
        }
    }
}
