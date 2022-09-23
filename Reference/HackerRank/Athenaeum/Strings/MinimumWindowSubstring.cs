using System.Collections.Generic;

namespace Athenaeum.Strings
{
    public static class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) ||
                string.IsNullOrEmpty(t))
            {
                return string.Empty;
            }

            var need = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();

            foreach (var character in t)
            {
                if (need.ContainsKey(character))
                {
                    need[character] += 1;
                }
                else
                {
                    need.Add(character, 1);
                }
            }

            var left = 0;
            var right = 0;

            var valid = 0;
            var start = 0;
            var len = int.MaxValue;

            while (right < s.Length)
            {
                var c = s[right];
                right += 1;

                if (need.ContainsKey(c))
                {
                    if (window.ContainsKey(c))
                    {
                        window[c]++;
                    }
                    else
                    {
                        window.Add(c, 1);
                    }

                    if (window[c] == need[c])
                    {
                        valid += 1;
                    }
                }

                while (valid == need.Count)
                {
                    if (right - left < len)
                    {
                        start = left;
                        len = right - left;
                    }

                    var d = s[left];
                    left += 1;

                    if (need.ContainsKey(d))
                    {
                        if (window[d] == need[d])
                        {
                            valid -= 1;
                        }

                        window[d] -= 1;
                    }
                }
            }

            return len == int.MaxValue ? string.Empty : s.Substring(start, len);
        }
    }
}