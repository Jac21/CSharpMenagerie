using Athenaeum.Stacks;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Stacks;

public class BalanceBracketsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BalancedBrackets_SimpleCase_Success()
    {
        // arrange
        const string input = "{[()]}";

        // act
        var simpleCase = BalanceBrackets.IsBalanced(input);

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void BalancedBrackets_SimpleCaseTwo_Success()
    {
        // arrange
        const string input = "{}()";

        // act
        var simpleCase = BalanceBrackets.IsBalanced(input);

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void BalancedBrackets_SimpleCaseThree_Success()
    {
        // arrange
        const string input = "{(})";

        // act
        var simpleCase = BalanceBrackets.IsBalanced(input);

        // assert
        Assert.IsFalse(simpleCase);
    }

    [Test]
    public void BalancedBrackets_SimpleCaseFour_Success()
    {
        // arrange
        const string input = ")";

        // act
        var simpleCase = BalanceBrackets.IsBalanced(input);

        // assert
        Assert.IsFalse(simpleCase);
    }
}