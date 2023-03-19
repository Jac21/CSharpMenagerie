using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class TwoSumFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TwoSumFinder_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = TwoSumFinder.TwoSum(new[] {2, 7, 11, 15}, 9);

        // assert
        Assert.AreEqual(new[] {0,1}, simpleCase);
    }

    [Test]
    public void TwoSumFinder_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = TwoSumFinder.TwoSum(new[] {3, 2, 4}, 6);

        // assert
        Assert.AreEqual(new[] {1, 2}, simpleCase);
    }

    [Test]
    public void TwoSumFinder_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = TwoSumFinder.TwoSum(new[] {3, 3}, 6);

        // assert
        Assert.AreEqual(new[] {0, 1}, simpleCase);
    }
}