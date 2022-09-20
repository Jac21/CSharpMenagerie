namespace Athenaeum.Arrays
{
    public static class NumberOfIslands
    {
        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;

            var rows = grid.Length;
            var columns = grid[0].Length;
            var islands = 0;

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    if (grid[row][column] == '1')
                    {
                        PerformIslandChecksViaDfs(grid, row, column);
                        islands += 1;
                    }
                }
            }

            return islands;
        }

        private static void PerformIslandChecksViaDfs(char[][] grid, int row, int column)
        {
            if (row < 0 ||
                row >= grid.Length ||
                column < 0 ||
                column >= grid[0].Length ||
                grid[row][column] != '1')
            {
                return;
            }
            
            // mark as visited
            grid[row][column] = char.MaxValue;
            
            // up
            PerformIslandChecksViaDfs(grid, row - 1, column);
            
            // down
            PerformIslandChecksViaDfs(grid, row + 1, column);
            
            // left
            PerformIslandChecksViaDfs(grid, row, column - 1);
            
            // right
            PerformIslandChecksViaDfs(grid, row, column + 1);
        }
    }
}