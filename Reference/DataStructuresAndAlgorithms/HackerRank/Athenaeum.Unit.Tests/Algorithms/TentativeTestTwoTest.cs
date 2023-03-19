using Athenaeum.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms;

public class TentativeTestTwoTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TentativeTestTwo_SimpleCase_Success()
    {
        // arrange

        // act
        var result = TentativeTestTwo.solution(new[] {3, 2, 4, 3}, 2, 4);

        // assert
        Assert.AreEqual(new[] {6, 6}, result);
    }

    [Test]
    [Ignore("Gotta figure it out")]
    public void TentativeTestTwo_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var result = TentativeTestTwo.solution(new[] {1, 5, 6}, 4, 3);

        // assert
        Assert.AreEqual(new[] {2, 1, 2, 4}, result);
    }

    [Test]
    public void TentativeTestTwo_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var result = TentativeTestTwo.solution(new[] {1, 2, 3, 4}, 4, 6);

        // assert
        Assert.AreEqual(new[] {0}, result);
    }

    [Test]
    public void TentativeTestTwo_SimpleCaseFour_Success()
    {
        // arrange

        // act
        var result = TentativeTestTwo.solution(new[] {6, 1}, 1, 1);

        // assert
        Assert.AreEqual(new[] {0}, result);
    }
}