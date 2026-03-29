using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Arrays.He
{
    /*
     * Problem
Given an array 
 of 
 integers. Find the number of unordered pairs 
, 
 such that 

 is odd where 
 represents bitwise XOR operation.
Input format

The first line contains three space-separated integers 
.
The next line contains 
 space-separated integers denoting the array 
Output format

Print the number of unordered pairs 
 which satisfy the above conditions in a new line.

Constraints


 

Sample Input
4 2 10
1 2 3 4
Sample Output
4
Time Limit: 1
Memory Limit: 256
Source Limit:
Explanation
Following unordered pairs satisfy the above conditions:

(1,2)
(1,4)
(2,3)
(3,4)
     */
    public class FindPairs
    {
        public static void Main()
        {
            var inputLineSplit = Console.ReadLine().Split();

            var n = inputLineSplit[0];
            var l = long.Parse(inputLineSplit[1]);
            var r = long.Parse(inputLineSplit[2]);

            var array = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            // split array into odd and even
            var evens = new List<long>();
            var odds = new List<long>();

            foreach (var num in array)
            {
                if (num % 2 == 0)
                {
                    evens.Add(num);
                }
                else
                {
                    odds.Add(num);
                }
            }

            evens.Sort();
            odds.Sort();

            var result = CountValidPairs(evens, odds, r) - CountValidPairs(evens, odds, l - 1);

            Console.WriteLine(result);
        }

        private static long CountValidPairs(List<long> listOne, List<long> listTwo, long target)
        {
            if (listOne.Count == 0 ||
                listTwo.Count == 0)
            {
                return 0;
            }

            long count = 0;
            int right = listTwo.Count - 1;

            // for each element in list one,
            // find elements in list two that
            // satisfy sum
            for (int left = 0; left < listOne.Count; left++)
            {
                while (right >= 0 &&
                       listOne[left] + listTwo[right] > target)
                {
                    right--;
                }

                if (right < 0) break;
                count += (right + 1);
            }

            return count;
        }
    }
}