using System;

namespace Athenaeum.Strings
{
    public static class LongestRepeatingCharacterReplacement
    {
        public static int CharacterReplacement(string s, int k)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var maxLength = 0;
            int start = 0, maxCount = 0;

            var count = new int[26];

            for (var end = 0; end < s.Length; end++)
            {
                var index = s[end] - 'A';

                count[index]++;
                maxCount = Math.Max(maxCount, count[index]);

                while (end - start + 1 - maxCount > k)
                {
                    count[s[start] - 'A']--;
                    start++;
                }

                var length = end - start + 1;

                maxLength = Math.Max(length, maxLength);
            }

            return maxLength;
        }
    }
}