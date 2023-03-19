using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming;

public class CombinationSumFourTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CombinationSumFour_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = CombinationSumFour.CombinationSum4(new[] {1, 2, 3}, 4);

        // assert
        Assert.AreEqual(7, simpleCase);
    }

    [Test]
    public void CombinationSumFour_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = CombinationSumFour.CombinationSum4(new[] {9}, 3);

        // assert
        Assert.AreEqual(0, simpleCase);
    }
}