using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming;

public class BestTimeToBuyAndSellStockFourTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BestTimeToBuyAndSellStockFour_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = BestTimeToBuyAndSellStockFour.MaxProfit(2, new[] {2, 4, 1});

        // assert
        Assert.AreEqual(2, simpleCase);
    }

    [Test]
    public void BestTimeToBuyAndSellStockFour_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = BestTimeToBuyAndSellStockFour.MaxProfit(2, new[] {3, 2, 6, 5, 0, 3});

        // assert
        Assert.AreEqual(7, simpleCase);
    }
}