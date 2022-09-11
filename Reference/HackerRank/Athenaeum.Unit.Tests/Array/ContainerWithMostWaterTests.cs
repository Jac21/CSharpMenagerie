using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class ContainerWithMostWaterTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ContainerWithMostWater_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = ContainerWithMostWater.MaxArea(new[] {1, 8, 6, 2, 5, 4, 8, 3, 7});

        // assert
        Assert.AreEqual(49, simpleCase);
    }

    [Test]
    public void ContainerWithMostWater_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = ContainerWithMostWater.MaxArea(new[] {1, 1});

        // assert
        Assert.AreEqual(1, simpleCase);
    }
}