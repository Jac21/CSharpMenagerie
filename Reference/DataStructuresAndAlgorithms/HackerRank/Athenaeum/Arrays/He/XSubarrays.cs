using System;
using System.Linq;

/*
 * You are given an array 
 of length 
 sorted in non-decreasing order and an integer 
. Find the number of subarrays such that the sum of the minimum and maximum element of that subarray is less than or equal to 
.

Input Format:

The first line contains an integer 
, which denotes the number of test cases.
The first line of each test case contains two integers, 
 and 
.
The next line of each test case contains 
 space-separated integers, elements of array 
.
Output Format:

For each test case, print the number of subarrays such that the sum of the minimum and maximum element of that subarray is less than or equal to 
.

Constraints:

Examples
Input

2
3 6
3 4 16
4 5
1 3 5 8
Output

1
2
Explanation
For first test case:
Subarray is [3]. Hence, the answer is 1.

For second test case:
Subarrays are [1], [1, 3]. Hence, the answer is 2.
 */
namespace Athenaeum.Arrays.He
{
    public class XSubarrays
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for(var i = 0; i < testCaseCount; i++) {
                var input = Console.ReadLine().Split();

                var n = Convert.ToInt32(input[0]);
                var x = Convert.ToInt32(input[1]);

                var arrayInput = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                var result = Solve(n, x, arrayInput);

                Console.WriteLine(result);
            }
        }

        private static long Solve(int n, int x, long[] nums) {
            var count = 0L;
            var right = n - 1;

            for(var left = 0; left < n; left++) {
                // smallest subarray already breaks constraint, exit
                if(nums[left] + nums[left] > x) break;

                // start shrinking right until we meet the bounds
                while(right >= left && nums[left] + nums[right] > x) right -= 1;

                if(right >= left) count += (right - left + 1);
            }

            return count;
        }
    }
}