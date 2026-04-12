using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    public class MazeMaximum
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split();

            var n = Convert.ToInt32(line[0]);
            var m = Convert.ToInt32(line[1]);

            var maxRowMin = long.MinValue;

            var colMins = new long[m];
            for (var j = 0; j < m; j++) colMins[j] = long.MaxValue;

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().Split();
                var currentRowMin = long.MaxValue;

                for (var j = 0; j < m; j++)
                {
                    var val = Convert.ToInt64(row[j]);

                    // update row bottleneck
                    if (val < currentRowMin) currentRowMin = val;

                    // update column bottleneck
                    if (val < colMins[j]) colMins[j] = val;
                }

                if (currentRowMin > maxRowMin) maxRowMin = currentRowMin;
            }

            // find strongest of column bottlenecks
            var maxColMin = colMins.Max();

            // answer is intersection
            var result = Math.Min(maxRowMin, maxColMin);

            Console.WriteLine(result);
        }
    }
}