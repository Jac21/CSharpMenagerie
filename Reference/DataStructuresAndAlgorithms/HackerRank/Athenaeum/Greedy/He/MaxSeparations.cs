using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Greedy.He
{
    /*
     * Max separations
85% Success
3628 Attempts
20 Points
5s Time Limit
256MB Memory
1024 KB Max Code
You are working in the Data Consistency team of your company. You are allocated a task as follows:

You have a data stream consisting of an equal number of odd and even numbers. You can make separations in the data stream but the number of odd elements should be equal to the number of even elements in both partitions after separation. Also, if you make a separation between a number x and number y, then the cost of this operation will be |x-y| coins.
You are given the following:

An integer N
An array arr
An integer K
Task

Determine the maximum number of separations that can be made in the array by spending no more than K coins.

Example

Assumptions

N = 6
K = 4
arr = [1, 2, 5, 10, 5, 20]
Approach

The optimal answer is to split-sequence between 2 and 5. The price of this cut is equal to 3 coins, hence answer is 1.
Function description

Complete the function Decryptions() which takes an integer N and an array Arr. This function takes the following parameters and returns the required answer:

N: Represents the size of the data stream
K: Represents the limit of coins
arr: Represents the data stream
Input format

Note: This is the input format that you must use to provide custom input (available above the Compile and Test button).

The first line contains the integer N.
The second line contains integer K.
The third line contains N integers denoting the data stream.
Output format

Print the maximum number of separations that can be made in the array by spending no more than K coins.

Constraints




Code snippets (also called starter code/boilerplate code)

This question has code snippets for C, CPP, Java, and Python.

Examples
Input

4 
10
1 3 2 4
Output

0
Explanation
It is not possible to make even one cut even with an unlimited number of coins as the condition for valid separation can not be fulfilled in any separation.
     */
    public class MaxSeparations
    {
        private static void Main()
        {
            var line = Console.ReadLine();
            var N = Convert.ToInt32(line);
            line = Console.ReadLine();
            var K = Convert.ToInt32(line);
            line = Console.ReadLine();
            var arr = new int[N];
            arr = line.Split().Select(str => int.Parse(str)).ToArray();

            var out_ = Max(N, K, arr);
            Console.Out.WriteLine(out_);
        }

        static int Max(int N, int k, int[] arr)
        {
            var cutCosts = new List<int>();

            var oddCount = 0;
            var evenCount = 0;

            for(var i = 0; i < N - 1; i++) {
                if(arr[i] % 2 == 0) evenCount += 1;
                else oddCount +=1;

                // balance reached
                if(evenCount == oddCount) {
                    cutCosts.Add(Math.Abs(arr[i] - arr[i + 1]));
                }
            }

            cutCosts.Sort();

            var totalCuts = 0;
            var currentSpend = 0;

            foreach(var cost in cutCosts) {
                if(currentSpend + cost <= k) {
                    currentSpend += cost;
                    totalCuts += 1;
                } else {
                    break;
                }
            }

            return totalCuts;
        }

    }
}