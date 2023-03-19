using System.Linq;

namespace Athenaeum.Arrays
{
    public static class PositiveArrayEntryFinder
    {
        public static int Solution(int[] A)
        {
            if (A.Length == 0 ||
                A.All(x => x < 0))
            {
                return 1;
            }

            return Enumerable.Range(1, A.Length + 1).Except(A).Min();
        }
    }
}