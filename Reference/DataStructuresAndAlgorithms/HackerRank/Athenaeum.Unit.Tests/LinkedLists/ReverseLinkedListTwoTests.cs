using Athenaeum.LinkedLists;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.LinkedLists;

public class ReverseLinkedListTwoTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReverseLinkedListTwo_SimpleCase_Success()
    {
        // arrange
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        // act
        var simpleCase = ReverseLinkedListTwo.ReverseBetween(head, 2, 4);

        // assert
        Assert.IsNotNull(simpleCase);
    }
}