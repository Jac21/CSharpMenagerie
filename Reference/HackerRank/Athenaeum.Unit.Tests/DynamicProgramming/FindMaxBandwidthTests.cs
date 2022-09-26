using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming;

public class FindMaxBandwidthTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FindMaxBandwidth_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = FindMaxBandwidth.GetMaxBandwidth(new[]
        {
            new Slot {Start = 1, End = 30, Bandwidth = 2},
            new Slot {Start = 31, End = 60, Bandwidth = 4},
            new Slot {Start = 61, End = 120, Bandwidth = 3},
            new Slot {Start = 1, End = 20, Bandwidth = 2},
            new Slot {Start = 21, End = 40, Bandwidth = 4},
            new Slot {Start = 41, End = 60, Bandwidth = 5},
            new Slot {Start = 61, End = 120, Bandwidth = 3},
            new Slot {Start = 1, End = 60, Bandwidth = 4},
            new Slot {Start = 61, End = 120, Bandwidth = 4},
        });

        // assert
        Assert.AreEqual(13, simpleCase);
    }
}