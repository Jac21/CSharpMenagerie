using System.Collections.Generic;

namespace Athenaeum.Arrays
{
    public static class DuplicateFinder
    {
        public static bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length == 0) return false;

            var numsSet = new HashSet<int>();

            foreach (var num in nums)
            {
                if (numsSet.Contains(num))
                {
                    return true;
                }

                numsSet.Add(num);
            }

            return false;
        }
    }
}