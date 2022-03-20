using System.Collections.Generic;
using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree
{

    public class BinaryTreeInorderTraversalTests
    {
        private BinaryTreeInorderTraversal _binaryTreeInorderTraversal;

        [SetUp]
        public void Setup()
        {
            _binaryTreeInorderTraversal = new BinaryTreeInorderTraversal();
        }

        [Test]
        public void BinaryTreeInorderTraversal_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase =
                _binaryTreeInorderTraversal
                    .InorderTraversal(new TreeNode(1, null, new TreeNode(2, new TreeNode(3))));

            // assert
            Assert.AreEqual(new List<int> { 1, 3, 2 }, simpleCase);
        }

        [Test]
        public void BinaryTreeInorderTraversal_BaseCase_Success()
        {
            // arrange

            // act
            var baseCase = _binaryTreeInorderTraversal.InorderTraversal(new TreeNode());

            // assert
            Assert.AreEqual(new List<int>(), baseCase);
        }

        [Test]
        public void BinaryTreeInorderTraversal_BaseCaseTwo_Success()
        {
            // arrange

            // act
            var baseCaseTwo = _binaryTreeInorderTraversal.InorderTraversal(new TreeNode(1));

            // assert
            Assert.AreEqual(new List<int> { 1 }, baseCaseTwo);
        }

        [Test]
        public void BinaryTreeInorderTraversal_Iterative_SimpleCase_Success()
        {
            // arrange

            // act
            var simpleCase =
                _binaryTreeInorderTraversal
                    .InorderTraversalIterative(new TreeNode(1, null, new TreeNode(2, new TreeNode(3))));

            // assert
            Assert.AreEqual(new List<int> { 1, 3, 2 }, simpleCase);
        }

        [Test]
        public void BinaryTreeInorderTraversal_Iterative_BaseCase_Success()
        {
            // arrange

            // act
            var baseCase = _binaryTreeInorderTraversal.InorderTraversalIterative(new TreeNode());

            // assert
            Assert.AreEqual(new List<int>(), baseCase);
        }

        [Test]
        public void BinaryTreeInorderTraversal_Iterative_BaseCaseTwo_Success()
        {
            // arrange

            // act
            var baseCaseTwo = _binaryTreeInorderTraversal.InorderTraversalIterative(new TreeNode(1));

            // assert
            Assert.AreEqual(new List<int> { 1 }, baseCaseTwo);
        }
    }
}