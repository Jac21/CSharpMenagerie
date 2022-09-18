using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class MaximumDepthOfBinaryTreeTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MaximumDepthOfBinaryTree_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = MaximumDepthOfBinaryTree.MaxDepth(new TreeNode(3, new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7))));

        // assert
        Assert.AreEqual(3, simpleCase);
    }

    [Test]
    public void MaximumDepthOfBinaryTree_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = MaximumDepthOfBinaryTree.MaxDepth(new TreeNode(1, null, new TreeNode(2)));

        // assert
        Assert.AreEqual(2, simpleCase);
    }
}