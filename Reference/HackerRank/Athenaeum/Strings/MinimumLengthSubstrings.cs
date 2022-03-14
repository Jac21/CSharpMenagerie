using System.Linq;

namespace Athenaeum.Strings
{
    public static class MinimumLengthSubstrings
    {
        public static int MinLengthSubstring(string s, string t)
        {
            if (string.IsNullOrEmpty(s) ||
                string.IsNullOrEmpty(t))
            {
                return 0;
            }

            var lastIndex = 0;

            var characters = t.ToList();

            for (var i = 0; i < s.Length && characters.Count > 0; i++)
            {
                characters.Remove(s[i]);
                lastIndex += 1;
            }

            return lastIndex;
        }
    }
}