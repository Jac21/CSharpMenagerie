using HackerRank.DivideAndConquer;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DivideAndConquer;

public class TopKFrequentElementsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TopKFrequentElements_BaseCase_Success()
    {
        // arrange

        // act
        var baseCase = TopKFrequentElements.TopKFrequent(new[] {1}, 1);

        // assert
        Assert.AreEqual(new[] {1}, baseCase);
    }

    [Test]
    public void TopKFrequentElements_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = TopKFrequentElements.TopKFrequent(new[] {1, 1, 1, 2, 2, 3}, 2);

        // assert
        Assert.AreEqual(new[] {1, 2}, simpleCase);
    }

    [Test]
    public void TopKFrequentElements_HardCase_Success()
    {
        // arrange

        // act
        var hardCase = TopKFrequentElements.TopKFrequent(new[] {-1, -1}, 1);

        // assert
        Assert.AreEqual(new[] {-1}, hardCase);
    }
}