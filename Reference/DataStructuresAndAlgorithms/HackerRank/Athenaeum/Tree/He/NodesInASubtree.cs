using System;
using System.Collections.Generic;

namespace Athenaeum.Tree.He {
    public class NodesInASubtree {
        private static List<int>[] _adj;
        private static int[,] _counts;
        private static string _labels;

        public static void Main() {
            var inputLineSplit = Console.ReadLine().Split();

            var n = Convert.ToInt32(inputLineSplit[0]);
            var q = Convert.ToInt32(inputLineSplit[1]);

            _labels = Console.ReadLine();

            _adj = new List<int>[n + 1];
            for(int i = 1; i <= n; i++) _adj[i] = new List<int>();

            for(var i = 0; i < n - 1; i++) {
                var edge = Console.ReadLine().Split();

                var u = Convert.ToInt32(edge[0]);
                var v = Convert.ToInt32(edge[1]);

                _adj[u].Add(v);
                _adj[v].Add(u);
            }

            _counts = new int[n + 1, 26];

            DepthFirstSearch(1, 0);

            for(var i = 0; i < q; i++) {
                var queryInputSplit = Console.ReadLine().Split();

                var u = Convert.ToInt32(queryInputSplit[0]);
                char c = queryInputSplit[1][0];

                Console.WriteLine(_counts[u, c - 'a']);
            }
        }

        private static void DepthFirstSearch(int u, int p) {
            // count current node's characters
            _counts[u, _labels[u - 1] - 'a'] = 1;

            foreach(var v in _adj[u]) {
                if(v == p) continue; // skip parent

                DepthFirstSearch(v, u);

                // aggregate: parent count += child count for all 26 letters
                for(int i = 0; i < 26; i++) {
                    _counts[u, i] += _counts[v, i];
                }
            }
        }
    }
}