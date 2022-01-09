using NUnit.Framework;

namespace HackerRank.Unit.Tests;

public class LongestValidParenthesesTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LongestValidParentheses_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = LongestValidParentheses.FindLongestValidParentheses("(()");

        // assert
        Assert.AreEqual(2, simpleCase);
    }

    [Test]
    public void LongestValidParentheses_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCaseTwo = LongestValidParentheses.FindLongestValidParentheses(")()())");

        // assert
        Assert.AreEqual(4, simpleCaseTwo);
    }

    [Test]
    public void LongestValidParentheses_BaseCase_Success()
    {
        // arrange

        // act
        var baseCase = LongestValidParentheses.FindLongestValidParentheses("");

        // assert
        Assert.AreEqual(0, baseCase);
    }
}