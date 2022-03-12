using Athenaeum.Greedy;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Greedy;

public class SlowSumsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SlowSums_SimpleCase_Success()
    {
        // arrange
        var input = new[]
        {
            4, 2, 1, 3
        };

        // act
        var simpleCase = SlowSums.GetTotalTime(input);

        // assert
        Assert.AreEqual(26, simpleCase);
    }
}