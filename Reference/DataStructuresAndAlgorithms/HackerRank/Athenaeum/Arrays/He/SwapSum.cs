using System;
using System.Linq;
using System.Collections.Generic;

namespace Athenaeum.Arrays.He
{
    /*
     * Problem
You are given two arrays, 
 and 
 of length 
. In one operation, you can swap 
 and 
. Find the maximum sum of 
 after performing at most 
 operations.

Input format

The first line contains an integer 
, denoting the number of test cases.
The first line of each test case contains two integers, 
 and 
.
The second line of each test case contains 
 space-separated integers, elements of array 
.
The third line of each test case contains 
 space-separated integers, elements of array 
.
Output format

For each test case, print the maximum sum of 
 after performing at most 
 operations in a new line.

Constraints


 

Sample Input
2
5 3
1 3 1 3 1
2 4 1 6 5
3 1
1 5 1
3 4 2
Sample Output
17
9
Time Limit: 1
Memory Limit: 256
Source Limit:
Explanation
For test case 
: We can perform the operations at indexes 2, 4, and 5 (1-based indexing). 
 becomes 
 Hence, the answer is 
.

For test case 
: We can perform the operations at index 1 (1-based indexing). 
 becomes 
. Hence, the answer is 
.
     */
    public class SwapSum
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var inputSplit = Console.ReadLine().Split();

                var n = Convert.ToInt32(inputSplit[0]);
                var k = Convert.ToInt32(inputSplit[1]);

                var a = Console
                    .ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var b = Console
                    .ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var result = Solve(n, k, a, b);

                Console.WriteLine(result);
            }
        }

        private static long Solve(int n, int k, long[] a, long[] b)
        {
            if (n == 0 || k == 0)
            {
                return 0;
            }

            var currentSum = a.Sum();
            var positiveGains = new List<long>();

            for (var i = 0; i < n; i++)
            {
                if (b[i] > a[i])
                {
                    positiveGains.Add(b[i] - a[i]);
                }
            }

            var gainsToAdd = positiveGains
                .OrderByDescending(x => x)
                .Take(k)
                .ToArray()
                .Sum();

            return currentSum + gainsToAdd;
        }
    }
}