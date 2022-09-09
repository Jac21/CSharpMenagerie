using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class DuplicateFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DuplicateFinder_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = DuplicateFinder.ContainsDuplicate(new[] {1, 2, 3, 1});

        // assert
        Assert.AreEqual(simpleCase, true);
    }

    [Test]
    public void DuplicateFinder_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = DuplicateFinder.ContainsDuplicate(new[] {1, 2, 3, 4});

        // assert
        Assert.AreEqual(simpleCase, false);
    }

    [Test]
    public void DuplicateFinder_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = DuplicateFinder.ContainsDuplicate(new[] {1, 1, 1, 3, 3, 4, 3, 2, 4, 2});

        // assert
        Assert.AreEqual(simpleCase, true);
    }
}