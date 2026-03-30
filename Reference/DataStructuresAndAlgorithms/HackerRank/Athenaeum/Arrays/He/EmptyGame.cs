using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    /*
     * Problem
You are given an array 
 of length 
. In one move, select an integer 
 and do one of the following operations:

Choose one index 
 such that 
 and remove 
.
Choose two indices 
 and 
 such that 
 and 
 and remove 
 and 
 from the array.
Find the minimum number of moves required to make the array empty.

Input format:

The first line contains an integer 
 denoting the number of test cases.
The first line of each test case contains an integer 
 denoting the length of the array.
The second line of each test case contains 
 space-separated elements of the array 
.
Output format:

For each test case, print the minimum moves needed to make the array empty.

Constraints:




Sample Input
2
4
1 3 5 2
2
6 7
Sample Output
2
1
Time Limit: 1
Memory Limit: 256
Source Limit:
Explanation
For test case 1:

Choose 
. Remove 
 and 
. Now array 
.
Choose 
. Remove 
 and 
. Now array 
.
Hence, the minimum number of moves needed is 
.

For test case 2:

Choose 
. Remove 
 and 
. Now array 
.
Hence, the minimum number of moves needed is 
.
     */
    public class EmptyGame
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for(var i = 0; i < testCaseCount; i++) {
                var n = Convert.ToInt32(Console.ReadLine());

                var a = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var result = Solve(n, a);

                Console.WriteLine(result);
            }
        }

        private static int Solve(int n, int[] a)
        {
            if (n == 0) return 0;
            
            Array.Sort(a);

            var moves = 0;
            var i = 0;

            // maximize 2-element removals in greedy algorithm
            // e.g., try to pair A[i] with A[i + 1]
            // if A[i + 1] - A[i] <= 2, that's a pair
            while(i < n) {
                if(i + 1 < n && a[i+1] - a[i] <= 2) {
                    moves += 1;
                    i += 2; // skip both
                } else {
                    moves += 1;
                    i += 1; // take single
                }
            }

            return moves;
        }
    }
}