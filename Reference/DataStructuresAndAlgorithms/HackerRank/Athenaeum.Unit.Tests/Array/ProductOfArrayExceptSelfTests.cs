using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class ProductOfArrayExceptSelfTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ProductOfArrayExceptSelf_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = ProductOfArrayExceptSelf.ProductExceptSelf(new[] {1, 2, 3, 4});

        // assert
        Assert.AreEqual(simpleCase, new[] {24, 12, 8, 6});
    }

    [Test]
    public void ProductOfArrayExceptSelf_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = ProductOfArrayExceptSelf.ProductExceptSelf(new[] {-1, 1, 0, -3, 3});

        // assert
        Assert.AreEqual(simpleCase, new[] {0, 0, 9, 0, 0});
    }
}