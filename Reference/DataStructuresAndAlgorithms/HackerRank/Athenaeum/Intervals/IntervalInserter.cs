using System;
using System.Collections.Generic;

namespace Athenaeum.Intervals
{
    public static class IntervalInserter
    {
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
            {
                return new[] {newInterval};
            }

            var result = new List<int[]>();

            foreach (var interval in intervals)
            {
                // if the beginning entry of the new interval is greater than the 
                // ending entry of the existing interval, add the existing interval
                // to the results list (i.e., the beginning of the set of intervals)
                if (newInterval[0] > interval[1])
                {
                    result.Add(interval);
                }
                // if the ending entry of the new interval is less than the
                // beginning entry of the existing internval, add the new
                // interval to the results list and set that existing one to be 
                // added to the results dictionary (i.e., the end of the set of intervals)
                else if (newInterval[1] < interval[0])
                {
                    result.Add(newInterval);
                    newInterval = interval;
                }
                // coalesce intervals using the new interval as the pivot
                else
                {
                    newInterval[0] = Math.Min(interval[0], newInterval[0]);
                    newInterval[1] = Math.Max(interval[1], newInterval[1]);
                }
            }

            result.Add(newInterval);
            return result.ToArray();
        }
    }
}