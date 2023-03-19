using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Algorithms
{
    public static class CustomerQuerySuggestions
    {
        /*
         * Complete the 'searchSuggestions' function below.
         *
         * The function is expected to return a 2D_STRING_ARRAY.
         * The function accepts following parameters:
         *  1. STRING_ARRAY repository
         *  2. STRING customerQuery
         */

        public static List<List<string>> searchSuggestions(List<string> repository, string customerQuery)
        {
            if (string.IsNullOrEmpty(customerQuery)) return new List<List<string>>();

            var results = new List<List<string>>();

            var query = string.Empty;

            foreach (var character in customerQuery)
            {
                query += character;

                if (query.Length < 2) continue;

                var suggestions = repository
                    .OrderBy(x => x)
                    .Where(x => x.StartsWith(query, StringComparison.OrdinalIgnoreCase))
                    .Take(3)
                    .Select(x => x.ToLowerInvariant())
                    .ToList();
                
                if(suggestions.Any()) results.Add(suggestions);
            }

            return results;
        }
    }
}