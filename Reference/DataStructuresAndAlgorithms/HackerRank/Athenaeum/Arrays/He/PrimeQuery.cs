using System;
using System.Linq;
using System.Text;

/*
 * You are given an array 
 having 
 integers and 
 queries. Each query is described by two integers 
 and 
. For each query, find the number of pairs 
 such that 
 and 
 can be expressed as the sum of one or more prime numbers.

In the sum, you are allowed to use a prime number more than once.

Input format

The first line of input contains an integer 
 denoting the number of test cases.
The first line of each test case contains an integers 
.
The second line of each test case contains 
 space-separated integers 
.
Then 
 lines follow, each containing two space-separated integers 
 and 
.
Output format

For each query, print the number of pairs that satisfies the given conditions in a separate line.

Constraints


Examples
Input

1
5
2 4 1 0 5
2
3 5
1 5
Output

2
9
Explanation
In the first query the pairs will be -
\((3, 5) = A_3 + A_5 = 1 + 5 = 6\) and \(6\) can be expressed as the sum of primes \((2 + 2 + 2)\).
\((4, 5) = A_4 + A_5 = 0 + 5 = 5\) and \(5\) can be expressed as the sum of primes \((2 + 3)\).

In the second query pairs will be \((1, 2), (1, 3), (1, 4), (1, 5), (2, 3), (2, 4), (2, 5), (3, 5), (4, 5)\).
 */
namespace Athenaeum.Arrays.He {
    public class PrimeQuery {
        public static void Main() {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for(var i = 0; i < testCaseCount; i++) {
                var n = Convert.ToInt32(Console.ReadLine());

                // prefix sum building
                var a = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var prefixZeros = new int[n + 1];
                var prefixOnes = new int[n + 1];

                for(var p = 0; p < n; p++) {
                    prefixZeros[p + 1] = prefixZeros[p] + (a[p] == 0 ? 1 : 0);
                    prefixOnes[p + 1] = prefixOnes[p] + (a[p] == 1 ? 1 : 0);
                }

                var q = Convert.ToInt32(Console.ReadLine());

                var stringBuilder = new StringBuilder();

                for(int j = 0; j < q; j++) {
                    var range = Console.ReadLine().Split();
                    var l = Convert.ToInt32(range[0]);
                    var r = Convert.ToInt32(range[1]);

                    // range size k
                    long k = r - l + 1;
                    
                    // frequency of 0s and 1s in range [L,R]
                    long z = prefixZeros[r] - prefixZeros[l-1];
                    long o = prefixOnes[r] - prefixOnes[l-1];

                    // total pairs
                    long totalPairs = k * (k - 1) / 2;

                    // bad pairs: (0,0) or (0,1)
                    long badPairs = (z * (z - 1) / 2) + (z * o);

                    stringBuilder.AppendLine((totalPairs - badPairs).ToString());
                }

                Console.Write(stringBuilder.ToString());
            }
        }
    }
}