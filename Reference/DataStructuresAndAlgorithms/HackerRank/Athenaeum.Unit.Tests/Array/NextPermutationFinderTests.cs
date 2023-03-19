using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class NextPermutationFinderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NextPermutationFinder_SimpleCase_Success()
    {
        // arrange
        var nums = new[] {1, 2, 3};

        // act
        NextPermutationFinder.NextPermutation(nums);

        // assert
        Assert.AreEqual(new[] {1, 3, 2}, nums);
    }

    [Test]
    public void NextPermutationFinder_SimpleCaseTwo_Success()
    {
        // arrange
        var nums = new[] {3, 2, 1};

        // act
        NextPermutationFinder.NextPermutation(nums);

        // assert
        Assert.AreEqual(new[] {1, 2, 3}, nums);
    }

    [Test]
    public void NextPermutationFinder_SimpleCaseThree_Success()
    {
        // arrange
        var nums = new[] {1, 1, 5};

        // act
        NextPermutationFinder.NextPermutation(nums);

        // assert
        Assert.AreEqual(new[] {1, 5, 1}, nums);
    }
}