using System.Collections.Generic;
using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class BinaryTreeHorizontalViewTests
{
    private BinaryTreeHorizontalView _binaryTreeHorizontalView;

    [SetUp]
    public void Setup()
    {
        _binaryTreeHorizontalView = new BinaryTreeHorizontalView();
    }

    [Test]
    public void BinaryTreeRightSideView_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = _binaryTreeHorizontalView.HorizontalView(new TreeNode(1,
            new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, null, new TreeNode(6))));

        // assert
        Assert.IsNotNull(simpleCase);
        Assert.IsFalse(simpleCase.Contains(5));
    }
}