using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class FindFirstAndLastPositionOfElementInSortedArrayTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FindFirstAndLastPositionOfElementInSortedArray_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = FindFirstAndLastPositionOfElementInSortedArray.SearchRange(new[] {5, 7, 7, 8, 8, 10}, 8);

        // assert
        Assert.AreEqual(new[] {3, 4}, simpleCase);
    }

    [Test]
    public void FindFirstAndLastPositionOfElementInSortedArray_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = FindFirstAndLastPositionOfElementInSortedArray.SearchRange(new[] {5, 7, 7, 8, 8, 10}, 6);

        // assert
        Assert.AreEqual(new[] {-1, -1}, simpleCase);
    }

    [Test]
    public void FindFirstAndLastPositionOfElementInSortedArray_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = FindFirstAndLastPositionOfElementInSortedArray.SearchRange(System.Array.Empty<int>(), 0);

        // assert
        Assert.AreEqual(new[] {-1, -1}, simpleCase);
    }
}