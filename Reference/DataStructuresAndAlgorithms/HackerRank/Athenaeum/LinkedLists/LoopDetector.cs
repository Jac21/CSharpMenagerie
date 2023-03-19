using System.Collections.Generic;

namespace Athenaeum.LinkedLists
{
    public static class LoopDetector
    {
        /// <summary>
        /// O(N) where N is the number of nodes in the linked list
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static bool HasLoopHashSet(ListNode h)
        {
            if (h == null) return false;

            var nodeSet = new HashSet<int>();

            while (h != null)
            {
                if (nodeSet.Contains(h.Val))
                {
                    return true;
                }

                nodeSet.Add(h.Val);
                h = h.Next;
            }

            return false;
        }

        public static bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            ListNode fast = head, slow = head;

            while (fast?.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (slow == fast) return true;
            }

            return false;
        }
    }
}