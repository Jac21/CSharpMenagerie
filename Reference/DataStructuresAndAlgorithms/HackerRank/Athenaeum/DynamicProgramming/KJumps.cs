namespace Athenaeum.DynamicProgramming
{
    public static class KJumps
    {
        public static int Jump(int m, int n, int k)
        {
            if (m < 0 ||
                n < 0 ||
                k < 0)
            {
                return 0;
            }

            if (m == 0 &&
                n == 0 &&
                k == 0)
            {
                return 1;
            }

            if (k > m + 1 + n + 1) return 0;

            var ways = 0;

            for (var i = 0; i <= m; i++)
            {
                for (var j = 0; j <= n; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        ways += Jump(m - i, n - j, k - 1);
                    }
                }
            }

            return ways;
        }
    }
}