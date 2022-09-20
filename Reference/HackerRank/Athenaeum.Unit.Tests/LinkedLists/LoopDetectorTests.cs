using Athenaeum.LinkedLists;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.LinkedLists;

public class LoopDetectorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LoopDetector_HasLoopHashSet_SimpleCase_Success()
    {
        // arrange
        var head = new ListNode(1,
            new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(1)))))));

        // act
        var simpleCase = LoopDetector.HasLoopHashSet(head);

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void LoopDetector_HasLoopHashSet_SimpleCaseTwo_Success()
    {
        // arrange
        var head = new ListNode(1, new ListNode(2, new ListNode(1)));

        // act
        var simpleCase = LoopDetector.HasLoopHashSet(head);

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void LoopDetector_HasLoopHashSet_SimpleCaseThree_Success()
    {
        // arrange
        var head = new ListNode(1, new ListNode(2));

        // act
        var simpleCase = LoopDetector.HasLoopHashSet(head);

        // assert
        Assert.IsFalse(simpleCase);
    }

    [Test]
    public void LoopDetector_HasCycle_SimpleCase_Success()
    {
        // arrange
        var fourthNode = new ListNode(-4);

        var thirdNode = new ListNode(0, fourthNode);

        var secondNode = new ListNode(2, thirdNode);

        var head = new ListNode(3, secondNode);

        fourthNode.Next = secondNode;

        // act
        var simpleCase = LoopDetector.HasCycle(head);

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void LoopDetector_HasCycle_SimpleCaseTwo_Success()
    {
        // arrange
        var secondNode = new ListNode(2);

        var head = new ListNode(1, secondNode);

        secondNode.Next = head;
        
        // act
        var simpleCase = LoopDetector.HasCycle(head);

        // assert
        Assert.IsTrue(simpleCase);
    }

    [Test]
    public void LoopDetector_HasCycle_SimpleCaseThree_Success()
    {
        // arrange
        var head = new ListNode(1);

        // act
        var simpleCase = LoopDetector.HasCycle(head);

        // assert
        Assert.IsFalse(simpleCase);
    }
}