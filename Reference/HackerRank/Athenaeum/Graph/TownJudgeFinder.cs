using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Graph
{
    public static class TownJudgeFinder
    {
        public static int FindJudge(int n, int[][] trust)
        {
            if (n == 1 && trust.Length == 0)
            {
                return 1;
            }

            var citizens = new HashSet<int>();
            var citizensToTrusteesMapping = new Dictionary<int, HashSet<int>>();

            foreach (var pair in trust)
            {
                citizens.Add(pair.FirstOrDefault());

                if (!citizensToTrusteesMapping.ContainsKey(pair.Skip(1).FirstOrDefault()))
                {
                    citizensToTrusteesMapping[pair.Skip(1).FirstOrDefault()] = new HashSet<int>();
                }

                citizensToTrusteesMapping[pair.Skip(1).FirstOrDefault()].Add(pair.FirstOrDefault());
            }

            var judge = citizensToTrusteesMapping
                .FirstOrDefault(kvp => kvp.Value.Count == n - 1 && !citizens.Contains(kvp.Key))
                .Key;

            return judge == 0 ? -1 : judge;
        }
    }
}