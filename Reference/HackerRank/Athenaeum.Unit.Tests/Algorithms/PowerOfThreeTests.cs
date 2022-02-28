using Athenaeum.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms;

public class PowerOfThreeTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PowerOfThree_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = PowerOfThree.IsPowerOfThree(27);

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void PowerOfThree_BaseCase_Success()
    {
        // arrange

        // act
        var baseCase = PowerOfThree.IsPowerOfThree(0);

        // assert
        Assert.IsFalse(baseCase);
    }

    [Test]
    public void PowerOfThree_BaseCaseTwo_Success()
    {
        // arrange

        // act
        var baseCaseTwo = PowerOfThree.IsPowerOfThree(1);

        // assert
        Assert.IsTrue(baseCaseTwo);
    }

    [Test]
    public void PowerOfThree_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCaseTwo = PowerOfThree.IsPowerOfThree(9);

        // assert
        Assert.IsTrue(simpleCaseTwo);
    }

    [Test]
    public void PowerOfThree_HardCase_Success()
    {
        // arrange

        // act
        var hardCase = PowerOfThree.IsPowerOfThree(45);

        // assert
        Assert.IsFalse(hardCase);
    }
}