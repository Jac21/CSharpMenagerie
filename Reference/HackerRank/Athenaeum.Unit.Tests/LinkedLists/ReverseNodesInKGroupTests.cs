using Athenaeum.LinkedLists;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.LinkedLists;

public class ReverseNodesInKGroupTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReverseNodesInKGroup_SimpleCase_Success()
    {
        // arrange
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        // act
        var simpleCase = ReverseNodesInKGroup.ReverseKGroup(head, 2);

        // assert
        Assert.IsNotNull(simpleCase);
    }

    [Test]
    public void ReverseNodesInKGroup_SimpleCaseTwo_Success()
    {
        // arrange
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        // act
        var simpleCase = ReverseNodesInKGroup.ReverseKGroup(head, 3);

        // assert
        Assert.IsNotNull(simpleCase);
    }

    [Test]
    public void ReverseNodesInKGroup_SimpleCaseThree_Success()
    {
        // arrange
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        // act
        var simpleCase = ReverseNodesInKGroup.ReverseKGroup(head, 1);

        // assert
        Assert.IsNotNull(simpleCase);
    }
}