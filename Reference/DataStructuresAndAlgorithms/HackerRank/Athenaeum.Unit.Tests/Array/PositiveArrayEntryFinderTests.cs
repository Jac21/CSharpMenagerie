using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class PositiveArrayEntryFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PositiveArrayEntryFinder_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = PositiveArrayEntryFinder.Solution(new[] {1, 3, 6, 4, 1, 2});

        // assert
        Assert.AreEqual(5, simpleCase);
    }

    [Test]
    public void PositiveArrayEntryFinder_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = PositiveArrayEntryFinder.Solution(new[] {1, 2, 3});

        // assert
        Assert.AreEqual(4, simpleCase);
    }

    [Test]
    public void PositiveArrayEntryFinder_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = PositiveArrayEntryFinder.Solution(new[] {-1, -3});

        // assert
        Assert.AreEqual(1, simpleCase);
    }
}