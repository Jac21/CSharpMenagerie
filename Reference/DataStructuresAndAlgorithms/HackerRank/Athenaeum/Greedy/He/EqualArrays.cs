using System;
using System.Linq;

namespace Athenaeum.Greedy.He
{
    /*
     * You are given two arrays 
 and 
 of length 
 and 
 respectively. You can perform the following operation any number of times on 
 and 
.

Replace any subarray of the array with the sum of the elements in the subarray.
You want to make 
 and 
 equal. Find the maximum possible length of arrays 
 and 
 such that 
 is equal to 
. If it is impossible to make 
 and 
 equal then print 
.

Input format

The first line contains an integer 
, which denotes the number of test cases.
The first line of each test case contains two integers 
 and 
, denoting the length of the array 
 and 
.
The second line of each test case contains 
 space-separated integers, elements of array 
.
The third line of each test case contains 
 space-separated integers, elements of array 
.
Output format

For each test case, print the maximum possible length of arrays 
 and 
 such that 
 is equal to 
. If it is impossible to make 
 and 
 equal then print 
 in a new line.

Constraints



Examples
Input

2
3 4
3 2 2
1 3 1 3
5 3
1 3 2 2 3
4 2 5
Output

-1
3
Explanation
For test case \(1\): It can be proven that we cannot make \(A\) and \(B\) equal. Hence, the answer is \(-1\).

For test case \(2\): We can perform operations on \(A\) from index 1 to 2 and from index 4 to 5 (1-based indexing).
\(A\) and \(B\) after performing the operation is [4, 2, 5]. The maximum possible length is \(3\).
     */
    public class EqualNumbers
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var inputSplit = Console.ReadLine().Split();
                var n = Convert.ToInt32(inputSplit[0]);
                var m = Convert.ToInt32(inputSplit[1]);

                var a = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var b = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var result = Solve(n, m, a, b);

                Console.WriteLine(result);
            }
        }

        private static long Solve(int n, int m, long[] a, long[] b)
        {
            var totalCount = 0L;
            
            var sumA = 0L;

            var sumB = 0L;

            var left = 0L;

            var right = 0L;

            while(left < n || right < m) {
                if(sumA <= sumB && left < n) {
                    sumA += a[left++];
                } else if(sumA > sumB && right < m) {
                    sumB += b[right++];
                } else {
                    break;
                }
                
                if (sumA == sumB) {
                    totalCount += 1;
                    sumA = 0L;
                    sumB = 0L;
                }
            }

            return (left == n && right == m && sumA == sumB) ? 
                totalCount 
                : 
                -1;
        }
    }
}