using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class AlgorithmSwapTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AlgorithmSwap_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = AlgorithmSwap.HowManySwaps(new[] {5, 1, 4, 2});

        // assert
        Assert.AreEqual(4, simpleCase);
    }
}