using System;
using System.Linq;

namespace Athenaeum.Arrays
{
    public static class ContainsDuplicateThree
    {
        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {
            if (nums.Length == 0) return false;
            
            var sortedNums = nums
                .Select((value, index) => new {value, index})
                .OrderBy(x => x.value)
                .ToArray();

            for (var i = 0; i < sortedNums.Length; i++)
            {
                long currentNum = sortedNums[i].value;

                for (var j = i + 1; j < sortedNums.Length && (sortedNums[j].value - currentNum) <= valueDiff; j++)
                {
                    if (Math.Abs(sortedNums[i].index - sortedNums[j].index) <= indexDiff)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}