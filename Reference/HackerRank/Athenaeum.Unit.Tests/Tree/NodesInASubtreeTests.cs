using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree
{

    public class NodesInASubtreeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NumberOfVisibleNodes_SimpleCase_Success()
        {
            // arrange
            TreeNode root = new TreeNode(8,
                new TreeNode(3, new TreeNode(1), new TreeNode(6, new TreeNode(4), new TreeNode(7))),
                new TreeNode(10, null, new TreeNode(14, new TreeNode(13))));

            // act
            var simpleCase = NumberOfVisibleNodes.VisibleNodes(root);

            // assert
            Assert.AreEqual(4, simpleCase);
        }
    }
}