using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Heaps
{
    public static class MagicalCandyBags
    {
        public static int MaxCandiesIterative(int[] arr, int k)
        {
            if (arr.Length == 0) return 0;

            double result = 0;

            while (k > 0)
            {
                double maxBag = arr.Max();

                result += maxBag;

                var index = Array.IndexOf(arr, (int) maxBag);
                arr[index] = (int) Math.Floor(maxBag / 2);

                k -= 1;
            }

            return (int) result;
        }
        
        public static int MaxCandiesHeap(int[] arr, int k)
        {
            if (arr.Length == 0) return 0;

            double result = 0;
            
            // build poor-man's heap
            var maxValues = new List<int>();

            foreach (var t in arr)
            {
                maxValues.Add(t);
            }

            while (k > 0)
            {
                // "re-heap"
                maxValues.Sort((a,b) => b.CompareTo(a));
                
                double maxBag = maxValues.FirstOrDefault();
                maxValues.RemoveAt(0);

                result += maxBag;

                maxValues.Add((int) Math.Floor(maxBag / 2));

                k -= 1;
            }

            return (int) result;
        }
    }
}