using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class NumberOfIslandsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NumberOfIslands_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = NumberOfIslands.NumIslands(new[]
        {
            new[] {'1', '1', '1', '1', '0'},
            new[] {'1', '1', '0', '1', '0'},
            new[] {'1', '1', '0', '0', '0'},
            new[] {'0', '0', '0', '0', '0'}
        });

        // assert
        Assert.AreEqual(1, simpleCase);
    }

    [Test]
    public void NumberOfIslands_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = NumberOfIslands.NumIslands(new[]
        {
            new[] {'1', '1', '0', '0', '0'},
            new[] {'1', '1', '0', '0', '0'},
            new[] {'0', '0', '1', '0', '0'},
            new[] {'0', '0', '0', '1', '1'}
        });

        // assert
        Assert.AreEqual(3, simpleCase);
    }
}