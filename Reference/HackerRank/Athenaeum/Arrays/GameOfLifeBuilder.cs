using System;
namespace Athenaeum.Arrays
{
    public static class GameOfLifeBuilder
    {
        public static int[][] GameOfLife(int[][] board)
        {
            if (board.Length == 0) return new int[][] { };

            const int deathToLifeMarker = -1;
            const int lifeToDeathMarker = 2;

            var n = board.Length;
            var m = board[0].Length;

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    int liveNeighbors = DeriveLiveNeighborsCount(board, i, j, n, m);

                    var cell = board[i][j];

                    if (cell == 1 && (liveNeighbors < 2 || liveNeighbors > 3))
                    {
                        board[i][j] = lifeToDeathMarker;
                    }
                    else if (cell == 0 && liveNeighbors == 3)
                    {
                        board[i][j] = deathToLifeMarker;
                    }
                }
            }

            for (var i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    var cell = board[i][j];

                    if (cell == deathToLifeMarker)
                    {
                        board[i][j] = 1;
                    }
                    else if (cell == lifeToDeathMarker)
                    {
                        board[i][j] = 0;
                    }
                }
            }

            return board;
        }

        private static int DeriveLiveNeighborsCount(int[][] board, int i, int j, int n, int m)
        {
            int liveNeighbors = 0;

            for (int x = Math.Max(0, i - 1); x < Math.Min(n, i + 2); x++)
            {
                for (int y = Math.Max(0, j - 1); y < Math.Min(m, j + 2); y++)
                {
                    if (board[x][y] >= 1)
                    {
                        liveNeighbors += 1;
                    }
                }
            }

            liveNeighbors -= board[i][j];
            return liveNeighbors;
        }
    }
}
