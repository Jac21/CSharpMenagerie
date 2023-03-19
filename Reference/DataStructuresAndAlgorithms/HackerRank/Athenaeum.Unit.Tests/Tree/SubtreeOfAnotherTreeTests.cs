using System.Collections.Generic;
using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class SubtreeOfAnotherTreeTests
{
    private SubtreeOfAnotherTree _subtreeOfAnotherTree;

    [SetUp]
    public void Setup()
    {
        _subtreeOfAnotherTree = new SubtreeOfAnotherTree();
    }

    [Test]
    public void SubtreeOfAnotherTree_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase =
            _subtreeOfAnotherTree.IsSubtree(new TreeNode(3, new TreeNode(4, new TreeNode(1), new TreeNode(2)),
                new TreeNode(5)), new TreeNode(4, new TreeNode(1), new TreeNode(2)));

        // assert
        Assert.AreEqual(true, simpleCase);
    }

    [Test]
    public void SubtreeOfAnotherTree_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase =
            _subtreeOfAnotherTree.IsSubtree(new TreeNode(3,
                new TreeNode(4, new TreeNode(1), new TreeNode(2, new TreeNode(0))),
                new TreeNode(5)), new TreeNode(4, new TreeNode(1), new TreeNode(2)));

        // assert
        Assert.AreEqual(false, simpleCase);
    }
}