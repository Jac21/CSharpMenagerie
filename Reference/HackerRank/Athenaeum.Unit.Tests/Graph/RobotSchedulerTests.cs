using Athenaeum.Graph;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Graph;

public class RobotSchedulerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void RobotScheduler_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = RobotScheduler.CanSchedule(4, new[]
        {
            new[] {0, 1},
            new[] {1, 2},
            new[] {2, 3}
        });

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void RobotScheduler_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = RobotScheduler.CanSchedule(3, new[]
        {
            new[] {0, 1},
            new[] {1, 2},
            new[] {2, 0}
        });

        // assert
        Assert.IsFalse(simpleCase);
    }

    [Test]
    public void RobotScheduler_Kahn_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = RobotScheduler.CanScheduleKahn(4, new[]
        {
            new[] {0, 1},
            new[] {1, 2},
            new[] {2, 3}
        });

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void RobotScheduler_Kahn_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = RobotScheduler.CanScheduleKahn(3, new[]
        {
            new[] {0, 1},
            new[] {1, 2},
            new[] {2, 0}
        });

        // assert
        Assert.IsFalse(simpleCase);
    }
}