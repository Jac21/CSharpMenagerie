using Athenaeum.Heaps;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Heaps;

public class MedianFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MedianFinder_SimpleCase_Success()
    {
        // arrange
        var medianFinder = new MedianFinder();
        medianFinder.AddNum(1);
        medianFinder.AddNum(2);

        // act
        var resultOne = medianFinder.FindMedian();

        // arrange
        medianFinder.AddNum(3);

        // act
        var resultTwo = medianFinder.FindMedian();

        // assert
        Assert.AreEqual(1.5, resultOne);
        Assert.AreEqual(2.0, resultTwo);
    }
}