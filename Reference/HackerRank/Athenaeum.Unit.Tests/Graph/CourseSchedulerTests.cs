using Athenaeum.Graph;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Graph;

public class CourseSchedulerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CourseScheduler_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = CourseScheduler.CanFinish(2, new int[][]
        {
            new[] {1, 0}
        });

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void CourseScheduler_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = CourseScheduler.CanFinish(2, new int[][]
        {
            new[] {1, 0},
            new[] {0, 1}
        });

        // assert
        Assert.IsFalse(simpleCase);
    }
}