using System;

namespace Athenaeum.Search.BinarySearch
{
    public static class BadVersionFinder
    {
        public static int FirstBadVersion(int n)
        {
            var low = 1;
            var high = n;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;

                // first bad version is between current start and mid
                if (IsBadVersion(mid))
                {
                    high = mid - 1;
                }
                // first bad version is between current mid and end
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }

        private static bool IsBadVersion(int version)
        {
            Random random = new();

            var value = random.Next(1, 2);

            return value == 1;
        }
    }
}
