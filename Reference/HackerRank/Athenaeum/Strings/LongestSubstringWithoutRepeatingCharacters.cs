using System;
using System.Collections.Generic;

namespace Athenaeum.Strings
{
    public static class LongestSubstringWithoutRepeatingCharacters
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var counter = int.MinValue;
            var seenCharacters = new HashSet<char>();

            var left = 0;
            var i = 0;

            while (i < s.Length)
            {
                while (!seenCharacters.Add(s[i]))
                {
                    seenCharacters.Remove(s[left]);
                    left++;
                }

                counter = Math.Max(counter, i - left + 1);
                i++;
            }

            return counter;
        }
    }
}