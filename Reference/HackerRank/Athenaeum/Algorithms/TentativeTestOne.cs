using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Algorithms
{
    public static class TentativeTestOne
    {
        public static int solution(string S)
        {
            // sanity checks
            if (string.IsNullOrEmpty(S)) return 0;

            var result = 0;

            // build set containing entries and associated occurrences
            // to get distinct number of occurrences per chatacter
            var letterEntriesDictionary = new Dictionary<char, int>();

            foreach (var character in S)
            {
                if (!letterEntriesDictionary.ContainsKey(character))
                {
                    letterEntriesDictionary.Add(character, 1);
                }
                else
                {
                    letterEntriesDictionary[character] += 1;
                }
            }
            
            // return early in the event there are no non-distinct letters
            if (letterEntriesDictionary.Count == 1) return 0;

            // create a list of all character occurrences
            var nonDistinctOccurrences = letterEntriesDictionary
                .Values
                .OrderByDescending(x=>x)
                .ToList();

            // poor-man's priority-queue
            while (nonDistinctOccurrences.Count != 0)
            {
                nonDistinctOccurrences
                    .Sort((a, b) => b.CompareTo(a));

                // test largest elements to ensure distinctness
                var element = nonDistinctOccurrences.FirstOrDefault();
                nonDistinctOccurrences.RemoveAt(0);
                
                // break early if there are no entries to work with
                if (nonDistinctOccurrences.Count == 0)
                {
                    return result;
                }

                // iterate removal count if needed
                if (element == nonDistinctOccurrences.FirstOrDefault())
                {
                    // decrement until minimum values are hit
                    if (element > 1)
                    {
                        nonDistinctOccurrences.Add(element - 1);
                    }
                    
                    result += 1;
                }
            }

            return result;
        }
    }
}