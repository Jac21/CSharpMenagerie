using System.Collections.Generic;

namespace Athenaeum.Arrays
{
    public static class CandyDistributor
    {
        public static int DistributeCandies(int[] candyType)
        {
            if (candyType.Length == 0) return 0;

            var set = new HashSet<int>(candyType);

            if (set.Count == 1) return set.Count;

            if (candyType.Length % 2 == 0 &&
                candyType.Length / 2 <= set.Count)
            {
                return candyType.Length / 2;
            }

            return set.Count;
        }
    }
}
