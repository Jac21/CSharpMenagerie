using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Algorithms.Iterators
{
    /// <summary>
    /// https://techdevguide.withgoogle.com/resources/former-interview-question-flatten-iterators/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InterleavingFlattener<T>
    {
        private readonly Queue<IEnumerator<T>> iterqueue;

        /// <summary>
        /// O(k)
        /// </summary>
        /// <param name="iterlist"></param>
        public InterleavingFlattener(IEnumerator<T>[] iterlist)
        {
            iterqueue = new Queue<IEnumerator<T>>();

            for (var i = 0; i < iterlist.Length; i++)
            {
                iterqueue.Enqueue(iterlist[i]);
            }
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public T Next()
        {
            if (!HasNext()) throw new ArgumentOutOfRangeException();

            var iterator = iterqueue.Dequeue();

            var val = iterator.Current;

            if (iterator.MoveNext()) iterqueue.Enqueue(iterator);

            return val;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
        {
            return iterqueue.Any();
        }
    }
}
