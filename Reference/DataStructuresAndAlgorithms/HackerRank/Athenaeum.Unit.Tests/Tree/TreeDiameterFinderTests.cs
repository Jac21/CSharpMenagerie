using System.Collections.Generic;
using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class TreeDiameterFinderTests
{
    private TreeDiameterFinder _treeDiameterFinder;

    [SetUp]
    public void Setup()
    {
        _treeDiameterFinder = new TreeDiameterFinder();
    }

    [Test]
    public void TreeDiameterFinder_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase =
            _treeDiameterFinder.Diameter(new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3)));
        // assert
        Assert.AreEqual(4, simpleCase);
    }
}