using HackerRank.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class SameTreeTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SameTree_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = SameTree.IsSameTree(new TreeNode(1, new TreeNode(2), new TreeNode(3)),
            new TreeNode(1, new TreeNode(2), new TreeNode(3)));

        // assert
        Assert.AreEqual(true, simpleCase);
    }

    [Test]
    public void SameTree_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCaseTwo = SameTree.IsSameTree(new TreeNode(1, new TreeNode(2)),
            new TreeNode(1, null, new TreeNode(2)));

        // assert
        Assert.AreEqual(false, simpleCaseTwo);
    }

    [Test]
    public void SameTree_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCaseThree = SameTree.IsSameTree(new TreeNode(1, new TreeNode(2), new TreeNode(1)),
            new TreeNode(1, new TreeNode(1), new TreeNode(2)));

        // assert
        Assert.AreEqual(false, simpleCaseThree);
    }
}