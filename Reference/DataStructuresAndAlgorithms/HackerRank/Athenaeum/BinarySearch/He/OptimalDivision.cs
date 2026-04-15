using System;
using System.Linq;

namespace Athenaeum.BinarySearch.He
{
    public class OptimalDivision
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var inputLine = Console.ReadLine().Split();
                var n = Convert.ToInt32(inputLine[0]);
                var m = Convert.ToInt32(inputLine[1]);

                var a = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var result = Solve(n, m, a);

                Console.WriteLine(result);
            }
        }

        private static int Solve(int n, int m, int[] a)
        {
            if (n == 0) return 0;

            // smallest possible Max OR is largest single element
            var low = a.Max();

            // largest possible is OR of all elements
            var high = 0;
            foreach (var x in a) high |= x;

            var result = high;

            // binary search on the answer
            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                if (CanDivide(a, m, mid))
                {
                    result = mid; // this works, let's find a smaller value
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1; // threshold is too small, increase
                }
            }

            return result;
        }

        private static bool CanDivide(int[] a, int m, int threshold)
        {
            var segmentCount = 1;
            var currentOr = 0;

            foreach (var num in a)
            {
                // if greater than threshold, start new segment
                if ((currentOr | num) > threshold)
                {
                    segmentCount += 1;
                    currentOr = num;

                    // if we need more than m segments, this is impossible
                    if (segmentCount > m) return false;
                }
                else
                {
                    currentOr |= num;
                }
            }

            return true;
        }
    }
}