using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class MaximumSubarrayTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MaximumSubarray_SimpleCase_Success()
    {
        // arrange

        // act
        var simpleCase = MaximumSubarray.MaxSubArray(new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4});

        // assert
        Assert.AreEqual(6, simpleCase);
    }

    [Test]
    public void MaximumSubarray_SimpleCaseTwo_Success()
    {
        // arrange

        // act
        var simpleCase = MaximumSubarray.MaxSubArray(new[] {1});

        // assert
        Assert.AreEqual(1, simpleCase);
    }

    [Test]
    public void MaximumSubarray_SimpleCaseThree_Success()
    {
        // arrange

        // act
        var simpleCase = MaximumSubarray.MaxSubArray(new[] {5, 4, -1, 7, 8});

        // assert
        Assert.AreEqual(23, simpleCase);
    }
}