using System;
using System.Collections.Generic;

namespace Athenaeum.Graph
{
    public static class MinimizingPermutations
    {
        public static int MinOperations(int[] arr)
        {
            if (arr.Length == 0) return 0;

            var result = 0;

            var target = new int[arr.Length];

            var visited = new HashSet<int[]>();
            var queue = new Queue<int[]>();

            for (var i = 0; i < arr.Length; i++)
            {
                target[i] = 1;
            }

            queue.Enqueue(arr);
            visited.Add(arr);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                if (current == target)
                {
                    return result;
                }

                for (var j = 2; j < current.Length; j++)
                {
                    var next = new int[arr.Length];
                    Array.Copy(current, next, arr.Length);

                    Reverse(arr, j);

                    if (!visited.Contains(next))
                    {
                        visited.Add(next);
                        queue.Enqueue(next);
                    }
                }

                result += 1;
            }

            return result;
        }

        private static void Reverse(int[] arr, int index)
        {
            var i = 0;

            while (i < index)
            {
                var tmp = arr[i];
                arr[i] = arr[index - 1];
                arr[index - 1] = tmp;

                i++;
                index--;
            }
        }
    }
}