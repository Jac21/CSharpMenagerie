using System.ComponentModel;

namespace HackerRank.Algorithms
{
    public static class NthMagicalNumberFinder
    {
        private const int Modulo = 1_000_000_007;

        private static long GreatestCommonDivisor(long a, long b)
        {
            return a == 0 ? b : GreatestCommonDivisor(b % a, a);
        }

        private static long SmallestCommonMultiple(long a, long b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }

        public static int NthMagicalNumber(int n, int a, int b)
        {
            var smallestCommonMultiple = SmallestCommonMultiple(a, b);
            const long left = 1;
            var right = long.MaxValue;

            long CalculateCount(long mid)
            {
                long count = 0;
                count += mid / a;
                count += mid / b;
                count -= mid / smallestCommonMultiple;
                return count;
            }

            while (left < right)
            {
                if (right - left <= 1)
                {
                    break;
                }

                var mid = left + (right - left) / 2;
                var count = CalculateCount(mid);

                if (count >= n)
                {
                    right = mid;
                }
            }

            if (CalculateCount(left) == n)
            {
                return (int) (left % Modulo);
            }

            return (int) (right % Modulo);
        }
    }
}