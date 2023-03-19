using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming;

public class UniquePathFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void UniquePathFinder_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = UniquePathFinder.UniquePaths(3, 7);

        // assert
        Assert.AreEqual(28, simpleCase);
    }
}