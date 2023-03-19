using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming;

public class StairClimberTests
{
    public void Setup()
    {
    }

    [Test]
    public void StairClimber_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = StairClimber.ClimbStairs(2);

        // assert
        Assert.AreEqual(2, simpleCase);
    }

    [Test]
    public void StairClimber_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCaseTwo = StairClimber.ClimbStairs(3);

        // assert
        Assert.AreEqual(3, simpleCaseTwo);
    }
}