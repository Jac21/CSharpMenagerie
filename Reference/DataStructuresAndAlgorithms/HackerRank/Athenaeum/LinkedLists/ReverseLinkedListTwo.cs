namespace Athenaeum.LinkedLists
{
    public static class ReverseLinkedListTwo
    {
        public static ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head == null) return null;

            if (left == right) return head;

            ListNode current = head, prev = null;

            for (var i = 0; i < left - 1; i++)
            {
                prev = current;
                current = current.Next;
            }

            // create node at index 'left-1'
            var lastNodeOfFirstSlice = prev;

            var lastNodeOfSubList = current;

            // reverse between left and right
            for (var i = 0; current != null && i < right - left + 1; i++)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            if (lastNodeOfFirstSlice != null)
            {
                lastNodeOfFirstSlice.Next = prev;
            }
            else
            {
                head = prev;
            }

            lastNodeOfSubList.Next = current;

            return head;
        }
    }
}