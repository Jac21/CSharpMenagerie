using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class LargestRectangleInHistogramTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LargestRectangleInHistogram_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = LargestRectangleInHistogram.LargestRectangleArea(new[] {2, 1, 5, 6, 2, 3});

        // assert
        Assert.AreEqual(10, simpleCase);
    }

    [Test]
    public void LargestRectangleInHistogram_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = LargestRectangleInHistogram.LargestRectangleArea(new[] {2, 4});

        // assert
        Assert.AreEqual(4, simpleCase);
    }

    [Test]
    public void LargestRectangleInHistogram_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = LargestRectangleInHistogram.LargestRectangleArea(new[] {1,1});

        // assert
        Assert.AreEqual(2, simpleCase);
    }
}