using HackerRank.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms;

public class NthMagicalNumberFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NthMagicalNumberFinder_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = NthMagicalNumberFinder.NthMagicalNumber(1, 2, 3);

        // assert
        Assert.AreEqual(2, simpleCase);
    }

    [Test]
    [Ignore("Long running =(")]
    public void NthMagicalNumberFinder_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCaseTwo = NthMagicalNumberFinder.NthMagicalNumber(4, 2, 3);

        // assert
        Assert.AreEqual(6, simpleCaseTwo);
    }
}