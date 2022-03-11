using Athenaeum.Greedy;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Greedy;

public class ElementSwappingTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ElementSwapping_SimpleCase_Success()
    {
        // arrange
        var input = new[]
        {
            5, 3, 1
        };

        // act
        var simpleCase = ElementSwapping.FindMinArray(input, 2);

        // assert
        Assert.AreEqual(new[] {1, 5, 3}, simpleCase);
    }

    [Test]
    public void ElementSwapping_SimpleCaseTwo_Success()
    {
        // arrange
        var input = new[]
        {
            8, 9, 11, 2, 1
        };

        // act
        var simpleCase = ElementSwapping.FindMinArray(input, 3);

        // assert
        Assert.AreEqual(new[] {2, 8, 9, 11, 1}, simpleCase);
    }
}