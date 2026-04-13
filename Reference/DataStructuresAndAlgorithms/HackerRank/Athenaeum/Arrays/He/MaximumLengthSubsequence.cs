using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    /*
     * Maximum length subsequence
78% Success
1492 Attempts
20 Points
1s Time Limit
256MB Memory
1024 KB Max Code
You are given an array A consisting of N integers. A subsequence of the array is called good if every pair of elements in the subsequence have an absolute difference of at most 10.

Task

Determine the maximum possible length of good subsequence.

Example

Assumptions

N = 8
A = [1, 9, 14, 2, 17, 14, 5, 18]
Approach

Subsequence: [9,14,17,14,18] is good which is the maximum length subsequence.
Hence the output is 5.
Function description

Complete the function solve() which takes the following 2 parameters and returns an integer as the required answer:

N: Represents an integer denoting the size of the array
A: Represents an array of N integers
Input format

Note: This is the input format you must use to provide custom input (available above the Compile and Test button). 

The first line contains an integer N.
The second line contains an array A of N integers.
Output format

Print the maximum possible length of good subsequence.

Constraints

Examples
Input

10
4 5 10 101 2 129 131 130 118 14
Output

4
Explanation
Given

N = 10
A = [4, 5, 10, 101, 2, 129, 131, 130, 118, 14]
Approach

Subsequence: [4, 5, 10, 14] is good which is the maximum length subsequence.
So the output is 4.
     */
    public class MaximumLengthSubsequence
    {
        public static void Main()
        {
            string line;
            line = Console.ReadLine();
            var N = Convert.ToInt32(line);
            line = Console.ReadLine();
            var A = new int[N];
            A = line.Split().Select(str => int.Parse(str)).ToArray();

            var out_ = Solve(N, A);
            Console.Out.WriteLine(out_);
        }

        static int Solve(int N, int[] A)
        {
            if (N == 0) return 0;

            // sort to bring similar values closer together
            // o(nlogn)
            Array.Sort(A);

            var maxLen = 0;
            var left = 0;

            // slide
            // o(nlogn)
            for (var right = 0; right < N; right++)
            {
                while (A[right] - A[left] > 10) left += 1;

                var currentLength = right - left + 1;

                maxLen = Math.Max(maxLen, currentLength);
            }

            return maxLen;
        }
    }
}