using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class CountingAnalogousArraysTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CountingAnalogousArrays_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = CountingAnalogousArrays.CountAnalogousArrays(new[] {-2, -1, -2, 5}, 3, 10);

        // assert
        Assert.AreEqual(3, simpleCase);
    }
}