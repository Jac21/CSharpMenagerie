namespace Athenaeum._2DArrays.He
{
    public class PeakElementFinder
    {
        public static void Main()
        {
            var oneDimensionalResult = FindPeakElement(new[] {1, 2, 3, 2, 1});

            var twoDimensionalResult =
                FindPeakElement2D(new[] {new[] {10, 20, 30}, new[] {15, 32, 17}, new[] {21, 16, 35}});
        }

        private static int FindPeakElement(int[] nums)
        {
            // set initial window
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                // find midpoint
                var mid = left + (right - left) / 2;

                // walking uphill since peak is to the right
                if (nums[mid] < nums[mid + 1])
                {
                    left = mid + 1;
                }
                // walking downhill (or flat)
                else
                {
                    right = mid;
                }
            }

            // left and right have converged
            return left;
        }

        private static object FindPeakElement2D(int[][] matrix)
        {
            // set initial window
            var left = 0;
            var right = matrix[0].Length - 1;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                // find max element's row in current mid column
                var maxRow = 0;
                for (var i = 0; i < matrix.Length; i++)
                {
                    if (matrix[i][mid] > matrix[maxRow][mid])
                    {
                        maxRow = i;
                    }
                }
                
                // compare with right neighbor
                if (matrix[maxRow][mid] < matrix[maxRow][mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            
            // left and right converged, find max element in this column
            var finalMaxRow = 0;
            for (var i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][left] > matrix[finalMaxRow][left])
                {
                    finalMaxRow = i;
                }
            }

            return matrix[finalMaxRow][left];
        }
    }
}