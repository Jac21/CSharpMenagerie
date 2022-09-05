namespace Athenaeum.DynamicProgramming
{
    public static class StairClimber
    {
        public static int ClimbStairs(int n)
        {
            if (n == 0) return 0;

            var result = new int[n + 1];

            result[0] = 1;
            result[1] = 1;

            for (var i = 2; i <= n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }

            return result[n];
        }
    }
}