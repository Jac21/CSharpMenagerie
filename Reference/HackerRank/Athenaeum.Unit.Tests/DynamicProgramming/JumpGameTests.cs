using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming;

public class JumpGameTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void JumpGame_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = JumpGame.CanJump(new[] {2, 3, 1, 1, 4});

        // assert
        Assert.AreEqual(true, simpleCase);
    }

    [Test]
    public void JumpGame_Forward_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = JumpGame.CanJumpForward(new[] {2, 3, 1, 1, 4});

        // assert
        Assert.AreEqual(true, simpleCase);
    }

    [Test]
    public void JumpGame_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = JumpGame.CanJump(new[] {3, 2, 1, 0, 4});

        // assert
        Assert.AreEqual(false, simpleCase);
    }
}