using Athenaeum.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms;

public class TentativeTestOneTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TentativeTestOne_SimpleCase_Success()
    {
        // arrange

        // act
        var result = TentativeTestOne.solution("aaaabbbb");

        // assert
        Assert.AreEqual(1, result);
    }

    [Test]
    public void TentativeTestOne_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var result = TentativeTestOne.solution("ccaaffddecee");

        // assert
        Assert.AreEqual(6, result);
    }

    [Test]
    public void TentativeTestOne_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var result = TentativeTestOne.solution("eeee");

        // assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void TentativeTestOne_SimpleCaseFour_Success()
    {
        // arrange

        // act
        var result = TentativeTestOne.solution("example");

        // assert
        Assert.AreEqual(4, result);
    }
}