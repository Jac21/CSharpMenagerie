using Athenaeum.Sorting;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Sorting;

public class CountingTrianglesTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CountingTriangles_SimpleCase_Success()
    {
        // arrange
        var input = new[]
        {
            new[]
            {
                2, 2, 3
            },
            new[]
            {
                3, 2, 2
            },
            new[]
            {
                2, 5, 6
            }
        };

        // act
        var simpleCase = CountingTriangles.CountDistinctTriangles(input);

        // assert
        Assert.AreEqual(2, simpleCase);
    }

    [Test]
    public void CountingTriangles_SimpleCaseTwo_Success()
    {
        // arrange
        var input = new[]
        {
            new[]
            {
                8, 4, 6
            },
            new[]
            {
                100, 101, 102
            },
            new[]
            {
                84, 93, 173
            }
        };

        // act
        var simpleCase = CountingTriangles.CountDistinctTriangles(input);

        // assert
        Assert.AreEqual(3, simpleCase);
    }

    [Test]
    public void CountingTriangles_SimpleCaseThree_Success()
    {
        // arrange
        var input = new[]
        {
            new[]
            {
                5, 8, 9
            },
            new[]
            {
                5, 9, 8
            },
            new[]
            {
                9, 5, 8
            },
            new[]
            {
                9, 8, 5
            },
            new[]
            {
                8, 9, 5
            },
            new[]
            {
                8, 5, 9
            }
        };

        // act
        var simpleCase = CountingTriangles.CountDistinctTriangles(input);

        // assert
        Assert.AreEqual(1, simpleCase);
    }
}