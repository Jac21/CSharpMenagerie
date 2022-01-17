namespace HackerRank.Strings
{
    public static class PalindromicSubstrings
    {
        public static int CountSubstrings(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var result = 0;

            for (var i = 0; i < s.Length; i++)
            {
                result += CheckPalindrome(s, i, i + 1);
                result += CheckPalindrome(s, i, i);
            }

            return result;
        }

        private static int CheckPalindrome(string s, int l, int r)
        {
            var count = 0;

            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                count += 1;

                l -= 1;
                r += 1;
            }

            return count;
        }
    }
}