using System;
using System.Linq;

namespace Athenaeum.Stacks.He
{
    public class StackOperations
    {
        public static void Main()
        {
            var inputLineSplit = Console.ReadLine().Split();

            var n = Convert.ToInt64(inputLineSplit[0]);
            var k = Convert.ToInt64(inputLineSplit[1]);

            var array = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            var result = Solve(n, k, array);

            Console.WriteLine(result);
        }

        private static long Solve(long n, long k, long[] array)
        {
            // first case with single element and odd operations
            if (n == 1 && k % 2 != 0) return -1;

            var maxTop = -1L;

            // use k-1 ops to pop elements and identify top in last op
            var limit = (int) Math.Min(n, k - 1);
            for (var i = 0; i < limit; i++)
            {
                if (array[i] > maxTop) maxTop = array[i];
            }

            // use all k ops to pop
            if (k < n)
            {
                if (array[k] > maxTop) maxTop = array[k];
            }

            return maxTop;
        }
    }
}