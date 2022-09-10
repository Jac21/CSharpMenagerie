using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class SearchInRotatedSortedArrayTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SearchInRotatedSortedArray_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = SearchInRotatedSortedArray.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 0);

        // assert
        Assert.AreEqual(simpleCase, 4);
    }

    [Test]
    public void SearchInRotatedSortedArray_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = SearchInRotatedSortedArray.Search(new[] {4, 5, 6, 7, 0, 1, 2}, 3);

        // assert
        Assert.AreEqual(simpleCase, -1);
    }

    [Test]
    public void SearchInRotatedSortedArray_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = SearchInRotatedSortedArray.Search(new[] {1}, 0);

        // assert
        Assert.AreEqual(simpleCase, -1);
    }

    [Test]
    public void SearchInRotatedSortedArray_SimpleCaseFour_Success()
    {
        // arrange

        // act
        var simpleCase = SearchInRotatedSortedArray.Search(new[] {1}, 1);

        // assert
        Assert.AreEqual(simpleCase, 0);
    }

    [Test]
    public void SearchInRotatedSortedArray_SimpleCaseFive_Success()
    {
        // arrange

        // act
        var simpleCase = SearchInRotatedSortedArray.Search(new[] {1, 3}, 3);

        // assert
        Assert.AreEqual(simpleCase, 1);
    }
}