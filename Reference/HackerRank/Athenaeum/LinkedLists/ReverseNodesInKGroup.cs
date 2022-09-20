namespace Athenaeum.LinkedLists
{
    public static class ReverseNodesInKGroup
    {
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k == 0) return head;

            var current = head;
            ListNode result = null;
            ListNode previous = null;

            while (current != null)
            {
                var count = 0;
                var next = current;

                while (next != null &&
                       count < k)
                {
                    count += 1;
                    next = next.Next;
                }

                if (count == k)
                {
                    var reversedHead = ReverseList(current, k);

                    result ??= reversedHead;

                    current.Next = next;

                    if (previous != null)
                    {
                        previous.Next = reversedHead;
                    }
                }

                previous = current;
                current = next;
            }

            return result ?? head;
        }

        private static ListNode ReverseList(ListNode head, int k)
        {
            var count = 0;

            ListNode previous = null;

            var current = head;
            var next = current.Next;

            while (current != null &&
                   count < k)
            {
                current.Next = previous;
                previous = current;
                current = next;
                next = next?.Next;

                count += 1;
            }

            return previous;
        }
    }
}