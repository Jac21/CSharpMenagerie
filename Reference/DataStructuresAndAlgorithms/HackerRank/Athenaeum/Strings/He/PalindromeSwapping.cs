using System;
using System.Collections.Generic;

namespace Athenaeum.Strings.He
{
    public class PalindromeSwapping
    {
        private static void Main()
        {
            string line;
            string T;
            T = Console.ReadLine();
            string S;
            S = Console.ReadLine();

            var out_ = MakeEqual(T, S);
            Console.Out.WriteLine(out_ ? "YES" : "NO");
        }

        static bool MakeEqual(string t, string s)
        {
            if (string.IsNullOrEmpty(t) || string.IsNullOrEmpty(s)) return false;

            var n = s.Length;
            var possible = true;

            for (var i = 0; i < n / 2; i++)
            {
                var j = n - 1 - i;

                // collect quad
                var quad = new char[] {s[i], t[i], s[j], t[j]};

                // frequency map
                var counts = new Dictionary<char, int>();
                foreach (var c in quad)
                {
                    if (!counts.ContainsKey(c)) counts[c] = 0;

                    counts[c] += 1;
                }

                if (!CanFormPairs(counts))
                {
                    possible = false;
                    break;
                }
            }

            // handle middle element if the length is odd
            if (possible && n % 2 != 0)
            {
                var mid = n / 2;

                if (s[mid] != t[mid]) possible = false;
            }

            return possible;
        }

        private static bool CanFormPairs(Dictionary<char, int> counts)
        {
            // all quad is same character
            if (counts.Count == 1) return true;

            // two distinct characters
            if (counts.Count == 2)
            {
                foreach (var val in counts.Values)
                {
                    if (val != 2) return false; // non-two-way-splits are impossible
                }

                return true;
            }

            // 3 or 4 distinct characters are impossible
            return false;
        }
    }
}