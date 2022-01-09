using HackerRank.Greedy;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Greedy;

public class MaximizeSumArrayAfterKNegationsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FrequencyOfTheMostFrequentElement_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = MaximizeSumArrayAfterKNegations.LargestSumAfterKNegations(new[] {4, 2, 3}, 1);

        // assert
        Assert.AreEqual(5, simpleCase);
    }

    [Test]
    public void FrequencyOfTheMostFrequentElement_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCaseTwo = MaximizeSumArrayAfterKNegations.LargestSumAfterKNegations(new[] {3, -1, 0, 2}, 3);

        // assert
        Assert.AreEqual(6, simpleCaseTwo);
    }

    [Test]
    public void FrequencyOfTheMostFrequentElement_HardCase_Success()
    {
        // arrange

        // act
        var hardCase = MaximizeSumArrayAfterKNegations.LargestSumAfterKNegations(new[] {-2, 9, 9, 8, 4}, 5);

        // assert
        Assert.AreEqual(32, hardCase);
    }
}