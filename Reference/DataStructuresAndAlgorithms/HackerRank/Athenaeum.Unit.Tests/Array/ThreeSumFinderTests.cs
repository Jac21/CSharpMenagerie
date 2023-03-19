using System.Collections.Generic;
using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class ThreeSumFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ThreeSumFinder_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = ThreeSumFinder.ThreeSum(new[] {-1, 0, 1, 2, -1, -4});

        // assert
        Assert.AreEqual(simpleCase, new List<List<int>>
        {
            new()
            {
                -1, -1, 2
            },
            new()
            {
                -1, 0, 1
            }
        });
    }

    [Test]
    public void ThreeSumFinder_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = ThreeSumFinder.ThreeSum(new[] {0, 1, 1});

        // assert
        Assert.AreEqual(simpleCase, new List<List<int>>());
    }

    [Test]
    public void ThreeSumFinder_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = ThreeSumFinder.ThreeSum(new[] {0, 0, 0});

        // assert
        Assert.AreEqual(simpleCase, new List<List<int>>()
        {
            new()
            {
                0, 0, 0
            }
        });
    }

    [Test]
    public void ThreeSumFinder_SimpleCaseFour_Success()
    {
        // arrange

        // act
        var simpleCase = ThreeSumFinder.ThreeSum(new[] {-1, 0, 1});

        // assert
        Assert.AreEqual(simpleCase, new List<List<int>>()
        {
            new()
            {
                -1, 0, 1
            }
        });
    }

    [Test]
    public void ThreeSumFinder_SimpleCaseFive_Success()
    {
        // arrange

        // act
        var simpleCase = ThreeSumFinder.ThreeSum(new[] {0,0,0});

        // assert
        Assert.AreEqual(simpleCase, new List<List<int>>()
        {
            new()
            {
                0,0,0
            }
        });
    }
}