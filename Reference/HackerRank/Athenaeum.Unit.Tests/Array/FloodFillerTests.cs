using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class FloodFillerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FloodFiller_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = FloodFiller.FloodFill(new[] {new[] {1, 1, 1}, new[] {1, 1, 0}, new[] {1, 0, 1}}, 1, 1, 2);

        // assert
        Assert.AreEqual(new[] {new[] {2, 2, 2}, new[] {2, 2, 0}, new[] {2, 0, 1}}, simpleCase);
    }

    [Test]
    public void FloodFiller_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = FloodFiller.FloodFill(new[] {new[] {0, 0, 0}, new[] {0, 0, 0}}, 0, 0, 0);

        // assert
        Assert.AreEqual(new[] {new[] {0, 0, 0}, new[] {0, 0, 0}}, simpleCase);
    }
}