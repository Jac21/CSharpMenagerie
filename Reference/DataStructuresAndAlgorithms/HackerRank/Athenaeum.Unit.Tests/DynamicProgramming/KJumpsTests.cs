using Athenaeum.DynamicProgramming;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.DynamicProgramming;

public class KJumpsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void KJumps_SimpleCase_Success()
    {
        // arrange
        const int m = 2;
        const int n = 2;
        const int k = 2;

        // act
        var simpleCase = KJumps.Jump(m, n, k);

        // assert
        Assert.AreEqual(7, simpleCase);
    }
}