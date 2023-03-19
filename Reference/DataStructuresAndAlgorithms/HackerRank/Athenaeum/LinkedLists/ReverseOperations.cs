namespace Athenaeum.LinkedLists
{
    public static class ReverseOperations
    {
        public static ListNode Reverse(ListNode head)
        {
            var dummyNode = new ListNode(0, head);
            var prev = dummyNode;
            var curr = head;

            while (curr != null)
            {
                var start = curr;

                while (curr != null &&
                       curr.Val % 2 == 0)
                {
                    curr = curr.Next;
                }

                if (start != curr)
                {
                    prev.Next = ReverseSublist(start, curr);
                }

                if (curr != null)
                {
                    prev = curr;
                    curr = curr.Next;
                }
            }

            return dummyNode.Next;
        }

        private static ListNode ReverseSublist(ListNode start, ListNode? end)
        {
            var prev = end;
            var curr = start;

            while (curr != end)
            {
                var next = curr.Next;
                curr.Next = prev;

                prev = curr;
                curr = next;
            }

            return prev;
        }
    }
}