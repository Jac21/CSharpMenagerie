using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming;

public class HouseRobberTwoTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void HouseRobberTwo_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = HouseRobberTwo.Rob(new[] {2, 3, 2});

        // assert
        Assert.AreEqual(3, simpleCase);
    }

    [Test]
    public void HouseRobberTwo_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = HouseRobberTwo.Rob(new[] {1, 2, 3, 1});

        // assert
        Assert.AreEqual(4, simpleCase);
    }

    [Test]
    public void HouseRobberTwo_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = HouseRobberTwo.Rob(new[] {1, 2, 3});

        // assert
        Assert.AreEqual(3, simpleCase);
    }
}