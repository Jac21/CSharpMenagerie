using Athenaeum.Greedy;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Greedy;

public class FrequencyOfTheMostFrequentElementTests
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
        var simpleCase = FrequencyOfTheMostFrequentElement.MaxFrequency(new[] {1, 2, 4}, 5);

        // assert
        Assert.AreEqual(3, simpleCase);
    }

    [Test]
    public void FrequencyOfTheMostFrequentElement_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCaseTwo = FrequencyOfTheMostFrequentElement.MaxFrequency(new[] {1, 4, 8, 13}, 5);

        // assert
        Assert.AreEqual(2, simpleCaseTwo);
    }

    [Test]
    public void FrequencyOfTheMostFrequentElement_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCaseThree = FrequencyOfTheMostFrequentElement.MaxFrequency(new[] {3, 9, 6}, 2);

        // assert
        Assert.AreEqual(1, simpleCaseThree);
    }
}