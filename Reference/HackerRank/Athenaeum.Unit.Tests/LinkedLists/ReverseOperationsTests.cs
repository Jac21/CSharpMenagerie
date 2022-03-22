using Athenaeum.LinkedLists;
using NUnit.Framework;

namespace HackerRank.Unit.Tests.LinkedLists
{
    public class ReverseOperationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Ignore("Reference comparison")]
        public void ReverseOperation_SimpleCase_Success()
        {
            // arrange
            var head = new ListNode(1, new ListNode(2, new ListNode(8, new ListNode(9, new ListNode(12, new ListNode(16))))));

            // act
            var simpleCase = ReverseOperations.Reverse(head);

            // assert
            var expected = new ListNode(1, new ListNode(8, new ListNode(2, new ListNode(9, new ListNode(16, new ListNode(12))))));

            Assert.AreEqual(expected, simpleCase);
        }
    }
}
