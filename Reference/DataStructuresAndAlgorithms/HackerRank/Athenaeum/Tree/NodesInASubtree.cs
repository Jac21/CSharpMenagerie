using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Tree
{
    public static class NodesInASubtree
    {
        public static int[] CountOfNodes(TreeNodeWrapper root, List<Query> queries, string s)
        {
            Dictionary<int, char> dictionary = new();

            Dfs(root, dictionary, s);

            var res = new List<int>();

            foreach (var q in queries)
            {
                var count = s.Count(x => x == dictionary[q.v]);

                res.Add(count);
            }

            return res.ToArray();
        }

        private static void Dfs(TreeNodeWrapper root, Dictionary<int, char> results, string s)
        {

            if (root == null) return;

            if (!root.children.Any())
            {
                results[root.val] = s[root.val - 1];

                return;
            }

            results[root.val] = s[root.val - 1];

            foreach (var c in root.children)
            {
                Dfs(c, results, s);

                results[root.val] += results[c.val];
            }
        }
    }

    public class Query
    {
        public int v;
        public char c;

        public Query(int v, char c)
        {
            this.v = v;
            this.c = c;
        }
    }
}