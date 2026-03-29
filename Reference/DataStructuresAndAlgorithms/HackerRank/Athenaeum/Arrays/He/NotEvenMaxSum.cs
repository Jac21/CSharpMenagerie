using System;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    /*
     * Problem
You are given an array 
 of size 
 where 
 is a positive integer at 
 position.. Find out the maximum sum of the elements that can be obtained which is not even. If the sum can never be not even return 

Task

Find out the maximum sum of the elements that are not even.

Example



Approach:

First, we find the sum of all the elements which in this case is 
. Since the sum is odd and we have to find the maximum sum that is not even, it is the final answer.

Function description

Complete the function solve provided in the editor. This function takes the following two-parameter and returns the required answer:

: number of elements in the array.
: a list containing positive integers. 

Input Format:

The first line contains an integer 
 denoting the number of test cases
For each test case:
The first line contains the integer 
, the size of the array 

The second line contains the 
 spaced positive integer values.

Output Format:
For each test case, print the answer in a new line.

Constraints:


Sample Input
1
5
4 2 6 3 2
Sample Output
17
Time Limit: 1
Memory Limit: 256
Source Limit:
Explanation
First we find sum of all the elements of the array which is 
. Since the sum is odd and we have to find the maximum sum that is not even it is the final answer
     */
    public class NotEvenMaxSum
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var inputSize = Convert.ToInt32(Console.ReadLine());

                var inputArray = Console
                    .ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var result = Solve(inputSize, inputArray);

                Console.WriteLine(result);
            }
        }

        private static long Solve(int n, long[] array)
        {
            if (n == 0 ||
                array.Length == 0)
            {
                return 0;
            }

            long totalSum = 0;
            var smallestOdd = long.MaxValue;
            var hasOdd = false;

            foreach (var x in array)
            {
                totalSum += x;

                if (x % 2 != 0)
                {
                    hasOdd = true;
                    if (x < smallestOdd) smallestOdd = x;
                }
            }

            if (!hasOdd)
            {
                return 0;
            }
            else if (totalSum % 2 != 0)
            {
                return totalSum;
            }
            else
            {
                return totalSum - smallestOdd;
            }
        }
    }
}