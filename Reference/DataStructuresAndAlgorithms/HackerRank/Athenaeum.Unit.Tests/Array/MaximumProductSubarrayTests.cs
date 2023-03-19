using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class MaximumProductSubarrayTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MaximumProductSubarray_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = MaximumProductSubarray.MaxProduct(new[] {2, 3, -2, 4});

        // assert
        Assert.AreEqual(6, simpleCase);
    }

    [Test]
    public void MaximumProductSubarray_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = MaximumProductSubarray.MaxProduct(new[] {-2, 0, -1});

        // assert
        Assert.AreEqual(0, simpleCase);
    }
}