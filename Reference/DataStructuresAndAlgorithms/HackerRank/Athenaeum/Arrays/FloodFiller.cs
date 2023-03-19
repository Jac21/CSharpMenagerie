using System.Collections.Generic;

namespace Athenaeum.Arrays
{
    public static class FloodFiller
    {
        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            // the starting pixel is already the stated color,
            // so no changes are made to the image.
            if (image[sr][sc] == color) return image;

            // get and set starting pixel's color
            var originalColor = image[sr][sc];
            image[sr][sc] = color;

            var queue = new Queue<int[]>();
            queue.Enqueue(new[] {sr, sc});

            while (queue.Count > 0)
            {
                var pixel = queue.Dequeue();

                // update adjacent pixels if directionality critera are met

                // left
                if (pixel[0] - 1 > -1 &&
                    image[pixel[0] - 1][pixel[1]] == originalColor)
                {
                    image[pixel[0] - 1][pixel[1]] = color;
                    queue.Enqueue(new[] {pixel[0] - 1, pixel[1]});
                }

                // right
                if (pixel[0] + 1 < image.Length &&
                    image[pixel[0] + 1][pixel[1]] == originalColor)

                {
                    image[pixel[0] + 1][pixel[1]] = color;
                    queue.Enqueue(new[] {pixel[0] + 1, pixel[1]});
                }

                // down
                if (pixel[1] + 1 < image[0].Length &&
                    image[pixel[0]][pixel[1] + 1] == originalColor)

                {
                    image[pixel[0]][pixel[1] + 1] = color;
                    queue.Enqueue(new[] {pixel[0], pixel[1] + 1});
                }

                // up
                if (pixel[1] - 1 > -1 &&
                    image[pixel[0]][pixel[1] - 1] == originalColor)

                {
                    image[pixel[0]][pixel[1] - 1] = color;
                    queue.Enqueue(new[] {pixel[0], pixel[1] - 1});
                }
            }

            return image;
        }
    }
}