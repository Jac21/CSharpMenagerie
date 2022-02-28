using Athenaeum.Algorithms;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Algorithms;

public class ExtraLongFactorialsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ExtraLongFactorials_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = ExtraLongFactorials.ComputeExtraLongFactorials(25);

        // assert
        Assert.IsTrue(simpleCase > 0);
    }
}