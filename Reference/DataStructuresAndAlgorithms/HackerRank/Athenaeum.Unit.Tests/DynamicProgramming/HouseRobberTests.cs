using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming;

public class HouseRobberTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void HouseRobber_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = HouseRobber.Rob(new[] {1, 2, 3, 1});

        // assert
        Assert.AreEqual(4, simpleCase);
    }

    [Test]
    public void HouseRobber_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = HouseRobber.Rob(new[] {2, 7, 9, 3, 1});

        // assert
        Assert.AreEqual(12, simpleCase);
    }
}