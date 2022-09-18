using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class InvertBinaryTreeTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void InvertBinaryTreeDfs_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = InvertBinaryTree.InvertTreeDfs(new TreeNode(4,
            new TreeNode(2, new TreeNode(1), new TreeNode(3)),
            new TreeNode(7, new TreeNode(6), new TreeNode(9))));

        // assert
        Assert.AreEqual(4, simpleCase.Val);
        Assert.AreEqual(7, simpleCase.Left.Val);
        Assert.AreEqual(2, simpleCase.Right.Val);
    }

    [Test]
    public void InvertBinaryTreeDfs_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = InvertBinaryTree.InvertTreeDfs(new TreeNode(2, new TreeNode(1), new TreeNode(3)));

        // assert
        Assert.AreEqual(2, simpleCase.Val);
        Assert.AreEqual(3, simpleCase.Left.Val);
        Assert.AreEqual(1, simpleCase.Right.Val);
    }

    [Test]
    public void InvertBinaryTreeDfs_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = InvertBinaryTree.InvertTreeDfs(new TreeNode());

        // assert
        Assert.AreEqual(0, simpleCase.Val);
    }

    [Test]
    public void InvertBinaryTreeBfs_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = InvertBinaryTree.InvertTreeBfs(new TreeNode(4,
            new TreeNode(2, new TreeNode(1), new TreeNode(3)),
            new TreeNode(7, new TreeNode(6), new TreeNode(9))));

        // assert
        Assert.AreEqual(4, simpleCase.Val);
        Assert.AreEqual(7, simpleCase.Left.Val);
        Assert.AreEqual(2, simpleCase.Right.Val);
    }

    [Test]
    public void InvertBinaryTreeBfs_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = InvertBinaryTree.InvertTreeBfs(new TreeNode(2, new TreeNode(1), new TreeNode(3)));

        // assert
        Assert.AreEqual(2, simpleCase.Val);
        Assert.AreEqual(3, simpleCase.Left.Val);
        Assert.AreEqual(1, simpleCase.Right.Val);
    }

    [Test]
    public void InvertBinaryTreeBfs_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = InvertBinaryTree.InvertTreeBfs(new TreeNode());

        // assert
        Assert.AreEqual(0, simpleCase.Val);
    }
}