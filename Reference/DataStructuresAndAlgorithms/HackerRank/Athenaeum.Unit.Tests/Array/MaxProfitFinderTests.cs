using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class MaxProfitFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MaxProfitFinder_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = MaxProfitFinder.MaxProfit(new[] {7, 1, 5, 3, 6, 4});

        // assert
        Assert.AreEqual(5, simpleCase);
    }

    [Test]
    public void MaxProfitFinder_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = MaxProfitFinder.MaxProfit(new[] {7, 6, 4, 3, 1});

        // assert
        Assert.AreEqual(0, simpleCase);
    }
}