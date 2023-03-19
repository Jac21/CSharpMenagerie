using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class ShoppingOptionsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShoppingOptions_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = ShoppingOptions.GetNumberOfOptions(new[] {2, 3}, new[] {4}, new[] {2, 3}, new[] {1, 2}, 10);

        // assert
        Assert.AreEqual(4, simpleCase);
    }
}