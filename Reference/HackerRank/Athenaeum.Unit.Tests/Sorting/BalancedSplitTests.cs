using Athenaeum.Sorting;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Sorting;

public class BalancedSplitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BalancedSplit_SimpleCase_Success()
    {
        // arrange
        var input = new[]
        {
            1, 5, 7, 1
        };

        // act
        var simpleCase = BalancedSplit.BalancedSplitExistsIterative(input);

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void BalancedSplit_SimpleCaseTwo_Success()
    {
        // arrange
        var input = new[]
        {
            12, 7, 6, 7, 6
        };

        // act
        var simpleCase = BalancedSplit.BalancedSplitExistsIterative(input);

        // assert
        Assert.IsFalse(simpleCase);
    }

    [Test]
    public void BalancedSplit_SimpleCase_LessIterative_Success()
    {
        // arrange
        var input = new[]
        {
            1, 5, 7, 1
        };

        // act
        var simpleCase = BalancedSplit.BalancedSplitExistsLessIterative(input);

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void BalancedSplit_SimpleCaseTwo_LessIterative_Success()
    {
        // arrange
        var input = new[]
        {
            12, 7, 6, 7, 6
        };

        // act
        var simpleCase = BalancedSplit.BalancedSplitExistsLessIterative(input);

        // assert
        Assert.IsFalse(simpleCase);
    }
}