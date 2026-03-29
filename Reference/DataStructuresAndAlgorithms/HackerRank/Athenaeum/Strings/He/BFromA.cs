using System;

namespace Athenaeum.Strings.He
{
    /*
     * Problem
You are given two strings 
 and 
 of length 
 and 
 respectively consisting of lowercase English letters. You can make several strings using characters from 
. If you use any character of 
 to make the string, that character will be removed from 
.

That means if you select an integer 
 from 
 to the length of the string 
 and use 
, then the character 
 will be removed and the string length gets reduced by 
, the indices of characters to the right of the deleted one also get reduced by 
.

Find the maximum number of strings you can make the same as that of 
.

Input format

The first line contains an integer 
 denoting the number of test cases.
The first line of each test case contains two space-separated integers 
 and 
.
The second line of each test case contains the string 
.
The third line of each test case contains the string 
.
Output format

For each test case, print the maximum number of strings you can make the same as that of 
.

Constraints


 

Sample Input
2
4 3
hgeb 
ebh
7 3
xyzxyxx
xyx
Sample Output
1
2
Time Limit: 1
Memory Limit: 256
Source Limit:
Explanation
For test case 
: The first string uses characters at indexes 1, 3, and 4 (1-based indexing). Hence, the answer is 1.

For test case 
: The first string uses characters at indexes 1, 2, and 4 (1-based indexing). The second string uses characters at indexes 5, 6, and 7 (1-based indexing). Hence, the answer is 2.
     */
    public class BFromA
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var lineInputSplit = Console.ReadLine().Split();

                var n = Convert.ToInt32(lineInputSplit[0]);
                var m = Convert.ToInt32(lineInputSplit[1]);

                var a = Console.ReadLine().Trim();
                var b = Console.ReadLine().Trim();

                var result = Solver(n, m, a, b);

                Console.WriteLine(result);
            }
        }

        private static int Solver(int n, int m, string a, string b)
        {
            if (n == 0 || m == 0) return 0;

            // obtain character counts
            var aCharacterCounts = new int[26];
            foreach (var character in a)
            {
                aCharacterCounts[character - 'a']++;
            }

            var bCharacterCounts = new int[26];
            foreach (var character in b) 
            {
                bCharacterCounts[character - 'a']++;
            }

            // find the bottleneck
            var maximumNumber = int.MaxValue;
            bool possible = false;

            for (var i = 0; i < 26; i++)
            {
                if(bCharacterCounts[i] > 0) {
                    possible = true;

                    var canMake = aCharacterCounts[i] / bCharacterCounts[i];
                    maximumNumber = Math.Min(maximumNumber, canMake);
                }
            }

            return possible ? maximumNumber : 0;
        }
    }
}