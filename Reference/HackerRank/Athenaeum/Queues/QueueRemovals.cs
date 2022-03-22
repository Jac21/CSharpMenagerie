using System;

namespace Athenaeum.Queues
{
    public static class QueueRemovals
    {

        public static int[] FindPositions(int[] arr, int x)
        {
            if (arr.Length == 0 || x == 0) return Array.Empty<int>();

            x = Math.Min(x, arr.Length);

            int[] result = new int[x];
            int max;
            int start = 0;

            // O(x)
            for (int i = 0; i < x; i++)
            {
                int count = Math.Min(x, arr.Length - i);
                int maxElementAt = start;

                max = arr[maxElementAt];

                // O(n)
                while (count > 0)
                {
                    if (arr[start] != -1)
                    {
                        if (max < arr[start])
                        {
                            max = arr[start];
                            maxElementAt = start;
                        }

                        if (arr[start] > 0)
                        {
                            arr[start] = arr[start] - 1;
                        }

                        count -= 1;
                    }

                    start += 1;
                    start = start % arr.Length;
                }

                arr[maxElementAt] = -1;

                result[i] = maxElementAt + 1;
            }

            return result;
        }
    }
}
