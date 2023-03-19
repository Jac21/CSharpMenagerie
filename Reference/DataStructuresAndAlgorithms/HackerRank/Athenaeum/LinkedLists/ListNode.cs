namespace Athenaeum.LinkedLists
{
    public class ListNode
    {
        public readonly int Val;

        public ListNode Next;

        public ListNode(int val = 0)
        {
            Val = val;
        }

        public ListNode(int val = 0, ListNode next = null)
        {
            Val = val;
            Next = next;
        }
    }
}