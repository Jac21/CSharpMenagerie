using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Strings
{
    public static class MatchingPairsFinder
    {
        public static int MatchingPairs(string s, string t)
        {
            if (string.IsNullOrEmpty(s) ||
                string.IsNullOrEmpty(t))
            {
                return 0;
            }

            var mismatches = new HashSet<string>();

            var sToChar = s.ToCharArray();
            var tToChar = t.ToCharArray();

            var matching = 0;

            for (var i = 0; i < sToChar.Length; i++)
            {
                if (sToChar[i] != tToChar[i])
                {
                    mismatches.Add($"{sToChar[i]}{tToChar[i]}");
                }
                else
                {
                    matching += 1;
                }
            }

            foreach (var mismatch in mismatches)
            {
                var reversedString = mismatch.Reverse();

                if (mismatches.Contains(reversedString))
                {
                    return matching + 2;
                }
            }

            if (mismatches.Count <= 1)
            {
                matching -= 1;
            }

            if (mismatches.Count == 0)
            {
                matching -= 1;
            }

            return matching;
        }
    }
}