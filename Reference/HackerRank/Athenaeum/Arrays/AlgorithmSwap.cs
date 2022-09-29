namespace Athenaeum.Arrays
{
    public static class AlgorithmSwap
    {
        public static int HowManySwaps(int[] arr)
        {
            if (arr.Length == 0) return 0;

            var swaps = 0;

            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        (arr[j], arr[i]) = (arr[i], arr[j]);

                        swaps += 1;
                    }
                }
            }

            return swaps;
        }
    }
}