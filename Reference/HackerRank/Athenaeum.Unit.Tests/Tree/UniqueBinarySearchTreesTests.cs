using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree
{

    public class UniqueBinarySearchTreesTests
    {
        private UniqueBinarySearchTrees _uniqueBinarySearchTrees;

        [SetUp]
        public void Setup()
        {
            _uniqueBinarySearchTrees = new UniqueBinarySearchTrees();
        }

        [Test]
        public void UniqueBinarySearchTrees_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase = _uniqueBinarySearchTrees.NumTrees(3);

            // assert
            Assert.AreEqual(5, simpleCase);
        }

        [Test]
        public void UniqueBinarySearchTrees_SimpleCaseTwo_Success()
        {
            // arrange

            // act
            var simpleCaseTwo = _uniqueBinarySearchTrees.NumTrees(1);

            // assert
            Assert.AreEqual(1, simpleCaseTwo);
        }
    }
}