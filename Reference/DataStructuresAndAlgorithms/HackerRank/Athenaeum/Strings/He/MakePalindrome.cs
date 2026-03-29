using System;

namespace Athenaeum.Strings.He
{
    /*
     * Problem
There is a string that consists of lowercase english alphabets and we have to make the string a palindrome
For this, we have 
 types of operations
1. Re-arrange the string however you want (this operation is free)
2. Add a new character to the end of the string (this operation will cost 1Re)

Your task is to calculate the minimum amount of money to make the string a palindrome

Input Format:
The first line contains one integer 
 the number of test cases
The first line of every test case consists of 
, the length of the string 
The second line of every test case contains string 


Output Format:
For every test case output one integer, the minimum amount of money required to make the string a palindrome

Constraints:


Sample Input
1
4
aabb
Sample Output
0
Time Limit: 1
Memory Limit: 256
Source Limit:
Explanation
Here we can re-arrange the string as abba , we need no extra characters to make this a palindrome
     */
    public class MakePalindrome
    {
        public static void Main()
        {
            var testCaseCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < testCaseCount; i++)
            {
                var n = Convert.ToInt32(Console.ReadLine());
                var s = Console.ReadLine();

                var result = Solver(n, s);

                Console.WriteLine(result);
            }
        }

        private static int Solver(int n, string s)
        {
            if (n == 0 || string.IsNullOrEmpty(s)) return 0;

            // obtain character counts
            var characterCounts = new int[26];
            foreach (var character in s)
            {
                characterCounts[character - 'a']++;
            }

            // count all odds
            var oddCount = 0;
            for (var i = 0; i < 26; i++)
            {
                if (characterCounts[i] % 2 != 0) oddCount++;
            }

            // string is already a palindrome (or can be made one freely)
            if (oddCount <= 1) return 0;

            // need to add characters to make a palindrome
            return oddCount - 1;
        }
    }
}