using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Strings
{
    public static class FindLongestWord
    {
        public static string ExecuteBruteForce(string s, List<string> d)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            var output = string.Empty;

            var subsequences = new HashSet<string>();

            BuildSubsequences(s, string.Empty, subsequences);

            foreach (var word in d)
            {
                if (subsequences.Contains(word) &&
                    word.Length > output.Length)
                {
                    output = word;
                }
            }

            return output;
        }

        private static void BuildSubsequences(string input, string output, HashSet<string> subsequences)
        {
            if (input.Length == 0)
            {
                if (!subsequences.Contains(output))
                {
                    subsequences.Add(output);
                }

                return;
            }

            // Output is passed with including
            // the 1st character of the input string
            BuildSubsequences(input[1..],
                             output + input[0], subsequences);

            // Output is passed without
            // including the 1st character of the input string
            BuildSubsequences(input[1..],
                             output, subsequences);
        }

        public static string FindLongestWordInString(string letters, List<string> words)
        {
            if (string.IsNullOrEmpty(letters) ||
                words.Count == 0)
            {
                return string.Empty;
            }

            var letterPositions = new Dictionary<char, int>();

            foreach (var character in letters)
            {
                if (!letterPositions.ContainsKey(character))
                {
                    letterPositions[character] = letters.IndexOf(character);
                }
            }

            var output = string.Empty;
            var sortedWords = words.OrderByDescending(x => x);

            foreach (var word in sortedWords)
            {
                if (word.Length < output.Length) break;

                var position = 0;

                foreach (var letter in word)
                {
                    if (!letterPositions.ContainsKey(letter))
                    {
                        break;
                    }

                    var possiblePositions = letterPositions
                        .Where((kvp) =>
                            kvp.Key == letter && kvp.Value >= position
                        ).ToDictionary(p => p.Key, v => v.Value);

                    if (!possiblePositions.Any())
                    {
                        break;
                    }
                    else
                    {
                        position = possiblePositions.FirstOrDefault().Value;
                    }

                    output = word;
                }
            }

            return output;
        }
    }
}
