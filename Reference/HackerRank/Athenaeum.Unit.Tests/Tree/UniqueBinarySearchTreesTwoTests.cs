using Athenaeum.Tree;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Tree;

public class UniqueBinarySearchTreesTwoTests
{
    private UniqueBinarySearchTreesTwo _uniqueBinarySearchTreesTwo;

    [SetUp]
    public void Setup()
    {
        _uniqueBinarySearchTreesTwo = new UniqueBinarySearchTreesTwo();
    }

    [Test]
    public void UniqueBinarySearchTreesTwo_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = _uniqueBinarySearchTreesTwo.GenerateTrees(3);

        // assert
        Assert.AreEqual(5, simpleCase.Count);
    }

    [Test]
    public void UniqueBinarySearchTreesTwo_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = _uniqueBinarySearchTreesTwo.GenerateTrees(1);

        // assert
        Assert.AreEqual(1, simpleCase.Count);
    }
}