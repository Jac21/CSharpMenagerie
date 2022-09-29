using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class OptimizingBoxWeightsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void OptimizingBoxWeights_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = OptimizingBoxWeights.MinimalHeaviestSetA(new[] {3, 7, 5, 6, 2});

        // assert
        Assert.AreEqual(2, simpleCase.Length);
    }

    [Test]
    public void OptimizingBoxWeightsStack_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = OptimizingBoxWeights.MinimalHeaviestSetAStack(new[] {3, 7, 5, 6, 2});

        // assert
        Assert.AreEqual(2, simpleCase.Length);
    }
}