namespace Athenaeum.DynamicProgramming
{
    public static class UniquePathFinder
    {
        public static int UniquePaths(int m, int n)
        {
            if (m == 0 ||
                n == 0)
            {
                return 0;
            }

            var grid = new int[m, n];

            // set start position
            grid[0, 0] = 1;

            // set path count of left column to 1
            for (var i = 1; i < m; i++)
            {
                grid[i, 0] = 1;
            }

            // set path count of top row to 1
            for (var i = 1; i < n; i++)
            {
                grid[0, i] = 1;
            }

            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    grid[i, j] = grid[i - 1, j] + grid[i, j - 1];
                }
            }

            return grid[m - 1, n - 1];
        }
    }
}