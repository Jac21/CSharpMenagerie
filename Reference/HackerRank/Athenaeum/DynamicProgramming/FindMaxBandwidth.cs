using System;
using System.Collections.Generic;

namespace Athenaeum.DynamicProgramming
{
    public struct Slot
    {
        public int Start { get; set; }

        public int End { get; set; }

        public int Bandwidth { get; set; }
    }

    public static class FindMaxBandwidth
    {
        public static int GetMaxBandwidth(Slot[] slots)
        {
            if (slots.Length == 0) return 0;

            Array.Sort(slots, (a, b) =>
            {
                if (a.Start == b.Start) return a.End - b.End;

                return a.Start - b.Start;
            });

            var queue = new PriorityQueue<Slot, int>();

            var sum = 0;
            var max = 0;

            foreach (var slot in slots)
            {
                while (queue.Count > 0 && queue.Peek().End < slot.Start)
                {
                    sum -= queue.Dequeue().Bandwidth;
                }

                sum += slot.Bandwidth;
                queue.Enqueue(slot, slot.End);
                max = Math.Max(sum, max);
            }

            return max;
        }
    }
}