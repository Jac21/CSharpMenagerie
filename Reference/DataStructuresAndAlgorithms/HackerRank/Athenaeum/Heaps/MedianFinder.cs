using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Heaps
{
    public class MedianFinder
    {
        private readonly PriorityQueue<int, int> _minHeap;
        private readonly PriorityQueue<int, int> _maxHeap;

        public MedianFinder()
        {
            _minHeap = new PriorityQueue<int, int>();
            
            _maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }

        public void AddNum(int num)
        {
            _minHeap.Enqueue(num, num);

            var minHeapPeek = _minHeap.Dequeue();

            _maxHeap.Enqueue(minHeapPeek, minHeapPeek);

            if (_minHeap.Count < _maxHeap.Count)
            {
                var maxHeapPeek = _maxHeap.Dequeue();
                _minHeap.Enqueue(maxHeapPeek, maxHeapPeek);
            }
        }

        public double FindMedian()
        {
            return _minHeap.Count > _maxHeap.Count ? _minHeap.Peek() : (_minHeap.Peek() + _maxHeap.Peek()) / 2.0;
        }
    }
}