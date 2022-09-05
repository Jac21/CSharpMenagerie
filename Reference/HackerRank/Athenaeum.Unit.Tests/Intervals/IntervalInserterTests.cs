using Athenaeum.Intervals;
using Athenaeum.LinkedLists;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Intervals;

public class IntervalInserterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IntervalInserter_BaseCase_Success()
    {
        // arrange

        // act
        var baseCase = IntervalInserter.Insert(System.Array.Empty<int[]>(), new[] {5, 7});

        // assert
        Assert.AreEqual(new int[][]
        {
            new[] {5, 7},
        }, baseCase);
    }

    [Test]
    public void IntervalInserter_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = IntervalInserter.Insert(new int[][]
        {
            new[] {1, 3},
            new[] {6, 9}
        }, new[] {2, 5});

        // assert
        Assert.AreEqual(new int[][]
        {
            new[] {1, 5},
            new[] {6, 9}
        }, simpleCase);
    }

    [Test]
    public void IntervalInserter_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = IntervalInserter.Insert(new int[][]
        {
            new[] {1, 2},
            new[] {3, 5},
            new[] {6, 7},
            new[] {8, 10},
            new[] {12, 16}
        }, new[] {4, 8});

        // assert
        Assert.AreEqual(new int[][]
        {
            new[] {1, 2},
            new[] {3, 10},
            new[] {12, 16}
        }, simpleCase);
    }
}