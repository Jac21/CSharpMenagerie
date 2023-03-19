using Athenaeum.Arrays;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.Array;

public class ContainsDuplicateThreeTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ContainsDuplicateThree_SimpleCase_Success()
    {
        // arrange
        var nums = new[] {1, 2, 3, 1};

        // act
        var simpleCase = ContainsDuplicateThree.ContainsNearbyAlmostDuplicate(nums, 3, 0);

        // assert
        Assert.AreEqual(true, simpleCase);
    }

    [Test]
    public void ContainsDuplicateThree_SimpleCaseTwo_Success()
    {
        // arrange
        var nums = new[] {1, 5, 9, 1, 5, 9};

        // act
        var simpleCase = ContainsDuplicateThree.ContainsNearbyAlmostDuplicate(nums, 2, 3);

        // assert
        Assert.AreEqual(false, simpleCase);
    }
}