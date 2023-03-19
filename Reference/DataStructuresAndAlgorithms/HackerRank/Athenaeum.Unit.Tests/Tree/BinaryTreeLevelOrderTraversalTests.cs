using System.Linq;
using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class BinaryTreeLevelOrderTraversalTests
{
    private BinaryTreeLevelOrderTraversal _binaryTreeLevelOrderTraversal;

    [SetUp]
    public void Setup()
    {
        _binaryTreeLevelOrderTraversal = new BinaryTreeLevelOrderTraversal();
    }

    [Test]
    public void BinaryTreeLevelOrderTraversal_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = _binaryTreeLevelOrderTraversal.LevelOrder(new TreeNode(3, new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7))));

        // assert
        Assert.AreEqual(3, simpleCase.Count);
    }

    [Test]
    public void BinaryTreeLevelOrderTraversal_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = _binaryTreeLevelOrderTraversal.LevelOrder(new TreeNode(1));

        // assert
        Assert.AreEqual(1, simpleCase.Count);
    }

    [Test]
    public void BinaryTreeLevelOrderTraversal_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = _binaryTreeLevelOrderTraversal.LevelOrder(new TreeNode());

        // assert
        Assert.AreEqual(0, simpleCase.Count);
    }
}