using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    /*
     * Infinite arrays
59% Success
21033 Attempts
20 Points
3s Time Limit
256MB Memory
1024 KB Max Code
You are given an array 
 of size 
. You have also defined an array 
 as the concatenation of array 
 for infinite number of times. 
For example, if 
, then 
.

Now, you are given 
 queries. Each query consists of two integers, 
 and 
. Your task is to calculate the sum of the subarray of 
 from index 
 to 
.

Note: As the value of this output is very large, print the answer as modulus 
.

Input format

First line: 
 denoting the number of test cases
For each test case:
First line: Contains 
, the size of the array
Second line: Contains 
 space-separated integers corresponding to 
Third line: Contains 
 denoting the number of queries
Fourth line: Contains 
 space-separated integers corresponding to 
Fifth line: Contains 
 space-separated integers corresponding to 
Output format

For each test case, print 
 space-separated integers that denote the answers of the provided 
 queries. Print the answer to each test case in a new line.

Constraints

Examples
Input

1
3
4 1 5
3
1 3 9
4 7 10
Output

14 19 9 
Explanation
\(A=\{4,1,5\}\)
\(B=\{4,1,5,4,1,5,4,1,5,4,1,5,...\}\)
Query #1: 
L=1, R=4, elements are {4,1,5,4}. Sum=4+1+5+4=14.

Query #2:
L=3, R=7, elements are {5,4,1,5,4}. Sum=5+4+1+5+4=19.

Query #3:
L=9, R=10, elements are {5,4}. Sum=5+4=9.
     */
    public class InfiniteArrays
    {
        // Standard competitive programming modulo: 10^9 + 7
        private const long Modulo = 1000000007;

        public static void Main()
        {
            var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) return;
            
            var testCaseCount = Convert.ToInt32(line);

            for (var i = 0; i < testCaseCount; i++)
            {
                var n = Convert.ToInt32(Console.ReadLine());
                var a = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                          .Select(long.Parse).ToArray();

                // 1. Pre-process Prefix Sums (O(N))
                long[] pref = new long[n + 1];
                for (int k = 0; k < n; k++)
                {
                    pref[k + 1] = (pref[k] + a[k]) % Modulo;
                }
                long totalCycleSum = pref[n];

                var q = Convert.ToInt32(Console.ReadLine());
                // Ensure L and R are read as long to handle 10^18
                var qL = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(long.Parse).ToArray();
                var qR = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(long.Parse).ToArray();

                for (var j = 0; j < q; j++)
                {
                    // Prefix Sum Formula: S(R) - S(L-1)
                    long sumR = GetPrefixSum(qR[j], n, pref, totalCycleSum);
                    long sumLMinus1 = GetPrefixSum(qL[j] - 1, n, pref, totalCycleSum);

                    // Handle potential negative result from subtraction
                    long result = (sumR - sumLMinus1 + Modulo) % Modulo;

                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
        }

        private static long GetPrefixSum(long x, int n, long[] pref, long totalSum)
        {
            if (x <= 0) return 0;

            long numCycles = x / n;
            int remainder = (int)(x % n);

            // Calculate contribution from full cycles
            // We modulo numCycles to stay within long bounds during multiplication
            long cycleContribution = ((numCycles % Modulo) * (totalSum % Modulo)) % Modulo;
            
            // Calculate contribution from the partial cycle
            long remainderContribution = pref[remainder];

            return (cycleContribution + remainderContribution) % Modulo;
        }
    }
}