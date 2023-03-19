using System.Collections.Generic;
using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class BinaryTreeRightSideViewTests
{
    private BinaryTreeRightSideView _binaryTreeRightSideView;

    [SetUp]
    public void Setup()
    {
        _binaryTreeRightSideView = new BinaryTreeRightSideView();
    }

    [Test]
    public void BinaryTreeRightSideView_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = _binaryTreeRightSideView.RightSideView(new TreeNode(1, new TreeNode(2, null, new TreeNode(5)),
            new TreeNode(3, null, new TreeNode(4))));

        // assert
        Assert.AreEqual(new List<int> {1, 3, 4}, simpleCase);
    }

    [Test]
    public void BinaryTreeRightSideView_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = _binaryTreeRightSideView.RightSideView(new TreeNode(1, null, new TreeNode(3)));

        // assert
        Assert.AreEqual(new List<int> {1, 3}, simpleCase);
    }

    [Test]
    public void BinaryTreeRightSideView_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = _binaryTreeRightSideView.RightSideView(null);

        // assert
        Assert.AreEqual(new List<int>(), simpleCase);
    }

    [Test]
    public void BinaryTreeRightSideView_SimpleCaseFour_Success()
    {
        // arrange

        // act
        var simpleCase = _binaryTreeRightSideView.RightSideView(new TreeNode(1, null, new TreeNode(2)));

        // assert
        Assert.AreEqual(new List<int> {1, 2}, simpleCase);
    }
}