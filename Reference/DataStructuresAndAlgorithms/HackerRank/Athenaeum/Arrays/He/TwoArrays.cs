using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    /*
     * 2 arrays
91% Success
22125 Attempts
20 Points
1s Time Limit
256MB Memory
1024 KB Max Code
You are given 
 arrays 
 and 
, each of the size 
. Each element of these arrays is either a positive integer or 
. The total number of 
 that can appear over these 
 arrays are 
 and 
.

Now, you need to find the number of ways in which we can replace each 
 with a non-negative integer, such that the sum of both of these arrays is equal.

Input format

First line: An integer 
Second line: 
 space-separated integers, where the of these denotes 
Third line: 
 space-separated integers, where the 
 of these denotes 
Output format

If there exists a finite number 
, then print it. If the answer is not a finite integer, then print 'Infinite'.

Constraints



The 
 may spread out among both arrays, and their quantity is between 
 and 
 (both inclusive)

Sample Input 2

4
1 2 -1 4
3 3 -1 1
Sample Output 2

Infinite
Examples
Input

4
1 2 -1 4
3 3 3 1
Output

1
Explanation
We can replace the only 
 by 
, so that the sum of both of these arrays become 
.
     */
    public class TwoArrays
    {
        private const string Infinity = "Infinite";

        public static void Main()
        {
            var n = Convert.ToInt32(Console.ReadLine());

            var a = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            var b = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            var result = Solve(n, a, b);

            Console.WriteLine(result);
        }

        private static string Solve(int n, long[] a, long[] b)
        {
            if (n == 0) return Infinity;

            long sumA = 0, sumB = 0;
            int aTargetCount = 0, bTargetCount = 0;
            
            // capture sums and -1 counts in a single O(N) pass.
            for (int i = 0; i < n; i++)
            {
                long valA = a[i];
                if (valA == -1) aTargetCount++;
                else sumA += valA;

                long valB = b[i];
                if (valB == -1) bTargetCount++;
                else sumB += valB;
            }

            // handle case when sums are equal and no finite can be found
            if(aTargetCount > 0 && bTargetCount > 0) return Infinity;
            // all -1s are in a
            else if (aTargetCount > 0) return CalculateWays(sumB - sumA, aTargetCount).ToString();
            // all -1s are in b
            else return CalculateWays(sumA - sumB, bTargetCount).ToString();
        }

        private static long CalculateWays(long gap, int numNegatives) {
            if(gap < 0) return 0;

            if(numNegatives == 1) return 1;

            return gap + 1;
        }
    }
}