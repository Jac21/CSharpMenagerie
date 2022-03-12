using Athenaeum.Greedy;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Greedy;

public class SeatingArrangementsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SeatingArrangements_SimpleCase_Success()
    {
        // arrange
        var input = new[]
        {
            5, 10, 6, 8
        };

        // act
        var simpleCase = SeatingArrangements.MinOverallAwkwardness(input);

        // assert
        Assert.AreEqual(4, simpleCase);
    }
}