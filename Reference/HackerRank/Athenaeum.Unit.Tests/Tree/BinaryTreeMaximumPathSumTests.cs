using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class BinaryTreeMaximumPathSumTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BinaryTreeMaximumPathSum_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = BinaryTreeMaximumPathSum.MaxPathSum(new TreeNode(1, new TreeNode(2), new TreeNode(3)));

        // assert
        Assert.AreEqual(6, simpleCase);
    }

    [Test]
    public void BinaryTreeMaximumPathSum_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = BinaryTreeMaximumPathSum.MaxPathSum(new TreeNode(-10, new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7))));

        // assert
        Assert.AreEqual(42, simpleCase);
    }
}