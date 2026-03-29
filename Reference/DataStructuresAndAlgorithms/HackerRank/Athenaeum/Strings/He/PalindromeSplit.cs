using System;

namespace Athenaeum.Strings.He
{
    /*
     * Problem
You are given a string 
 consisting of lowercase English letters. Your task is to find the maximum number of palindromic subsequences that can be created from the given string. Each palindromic subsequence must have a length greater than 1, and each element of the string can be part of atmost one palindromic subsequence.

We'll call non-empty string 
 subsequence of string 
, where |S| is the length of string S. For example, strings "abcb", "cb" and "abacaba" are subsequences of string "abacaba".

Input format

The first line of input contains an integer 
 denoting the number of test cases.
Each test case consists the string 
.
Output format

For each test case, print the maximum number of palindromic subsequences you can create in a separate line.

Constraints


 

Sample Input
2
aaad
fdffd
Sample Output
1
2
Time Limit: 1
Memory Limit: 256
Source Limit:
Explanation
In the first test case you can create one palindromic subsequence. You can create "aa".
In the second test case you can create two palindromic subsequence. You can create "dfd", "ff".
     */
    public class PalindromeSplit
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var s = Console.ReadLine();

                var result = Solver(s);

                Console.WriteLine(result);
            }
        }

        private static int Solver(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var characterCounts = new int[26];
            foreach (var character in s)
            {
                characterCounts[character - 'a']++;
            }

            var maxPalindromes = 0;
            for (var i = 0; i < 26; i++)
            {
                maxPalindromes += characterCounts[i] / 2;
            }

            return maxPalindromes;
        }
    }
}