using HackerRank.Array;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class CarPoolerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CarPooler_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = CarPooler.CarPooling(new[]
        {
            new[] {2, 1, 5},
            new[] {3, 3, 7},
        }, 4);

        // assert
        Assert.IsFalse(simpleCase);
    }

    [Test]
    public void CarPooler_SecondSimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = CarPooler.CarPooling(new[]
        {
            new[] {2, 1, 5},
            new[] {3, 3, 7},
        }, 5);

        // assert
        Assert.IsTrue(simpleCase);
    }
}