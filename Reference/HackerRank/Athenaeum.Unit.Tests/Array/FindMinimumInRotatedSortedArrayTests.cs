using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class FindMinimumInRotatedSortedArrayTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FindMinimumInRotatedSortedArray_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = FindMinimumInRotatedSortedArray.FindMin(new[] {3, 4, 5, 1, 2});

        // assert
        Assert.AreEqual(simpleCase, 1);
    }

    [Test]
    public void FindMinimumInRotatedSortedArray_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = FindMinimumInRotatedSortedArray.FindMin(new[] {4, 5, 6, 7, 0, 1, 2});

        // assert
        Assert.AreEqual(simpleCase, 0);
    }

    [Test]
    public void FindMinimumInRotatedSortedArray_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = FindMinimumInRotatedSortedArray.FindMin(new[] {11, 13, 15, 17});

        // assert
        Assert.AreEqual(simpleCase, 11);
    }
}