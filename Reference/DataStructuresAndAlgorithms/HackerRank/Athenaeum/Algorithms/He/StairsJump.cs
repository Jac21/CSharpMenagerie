using System;

namespace Athenaeum.Algorithms.He
{
    public class StairsJump
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) return;

            var n = Convert.ToInt32(input);
            Console.WriteLine(IterativeStepSolver(n));
        }

        private static long IterativeStepSolver(int n)
        {
            // Base cases
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            // naive, fib approach
            // return FibSolver(n - 1) + FibSolver(n - 2);

            // Iterative approach to avoid redundant calculations
            long waysToReachStairOne = 1;
            long waysToReachStairTwo = 2;
            long current = 0;

            for (var i = 3; i <= n; i++)
            {
                current = waysToReachStairTwo + waysToReachStairOne;
                waysToReachStairOne = waysToReachStairTwo;
                waysToReachStairTwo = current;
            }

            return current;
        }
    }
}