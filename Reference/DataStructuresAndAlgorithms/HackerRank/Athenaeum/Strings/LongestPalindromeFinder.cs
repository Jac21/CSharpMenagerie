using System;

namespace Athenaeum.Strings
{
    public static class LongestPalindromeFinder
    {
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            int length = 0, start = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var evenLength = FindPalindromeLength(s, i, i + 1);

                var oddLength = FindPalindromeLength(s, i, i);

                var currentLength = Math.Max(evenLength, oddLength);

                if (currentLength > length)
                {
                    length = currentLength;

                    start = i - (length - 1) / 2;
                }
            }

            return s.Substring(start, length);
        }

        private static int FindPalindromeLength(string s, int left, int right)
        {
            while (left >= 0 &&
                   right < s.Length &&
                   s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }
    }
}