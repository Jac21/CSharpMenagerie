using System;
using System.Linq;

namespace Athenaeum.Binary.He
{
    /*
     * Problem
Given an array of integers, denoted as 
, and an integer 
, your task is to implement a sorting algorithm. The goal is to arrange the elements in 
 based on their Hamming Distance from the integer 
.

The Hamming Distance is defined as the count of differing bits in the binary representations of two integers.

The sorting should be done in ascending order of Hamming distance, and in case of a tie in Hamming Distances, the elements should be sorted in ascending numerical order.

Input Format:

Note: This is the input format that you must use to provide custom input (available above the Compile and Test button).

The first line contains 
 denoting the number of test cases. 
 also specifies the number of times you have to run the solve function on a different set of inputs. For each test case:

The first line contains the integer 
 and 
.
The second line contains the array 
 of length 
Output Format: For each test case, print the answer in a new line. 

Constraints:


Sample Input
1
3 2
4 5 6
Sample Output
6 4 5
Time Limit: 2
Memory Limit: 256
Source Limit:
Explanation
In the example, binary representation of 
 is "
". Similarly for array 
, the binary representation is 
. Now the hamming distance of each element of the array with 
 are 
. Hence sorting on the basis of Hamming Distance, the final output comes out to be 
.
     */
    public class HammingSort
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var T = Convert.ToInt32(line);

            for (var t_i = 0; t_i < T; t_i++)
            {
                var custom_input_1 = Console.ReadLine().Split(" ");
                var N = Convert.ToInt32(custom_input_1[0]);
                var K = Convert.ToInt32(custom_input_1[1]);
                line = Console.ReadLine();
                var A = new int[N];
                A = line.Split().Select(str => int.Parse(str)).ToArray();

                var out_ = solve(N, K, A);
                Console.Out.WriteLine(string.Join(" ", out_.Select(x => x.ToString()).ToArray()));
            }
        }

        static int[] solve(int N, int K, int[] A)
        {
            // You must complete the logic for the function that is provided
            // before compiling or submitting to avoid an error.
            // Write your code here
            if (N == 0 ||
                K == 0 ||
                A.Length == 0)
            {
                return new int[N];
            }

            var sortedResults = A
                .OrderBy(x =>
                {
                    var xor = x ^ K;

                    var count = 0;

                    while (xor > 0)
                    {
                        xor &= (xor - 1);
                        count++;
                    }

                    return count;
                })
                .ThenBy(x => x);

            return sortedResults.ToArray();
        }
    }
}