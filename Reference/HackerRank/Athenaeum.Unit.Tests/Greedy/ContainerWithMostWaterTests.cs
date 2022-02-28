using Athenaeum.Greedy;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Greedy;

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
    public void ContainerWithMostWater_BaseCase_Success()
    {
        // arrange

        // act
        var baseCase = ContainerWithMostWater.MaxArea(new[] {1, 1});

        // assert
        Assert.AreEqual(1, baseCase);
    }
}