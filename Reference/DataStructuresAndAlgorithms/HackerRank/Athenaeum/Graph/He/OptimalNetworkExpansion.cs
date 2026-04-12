using System;
using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Graph.He
{
    public class OptimalNetworkExpansion
    {
        public static void Main()
        {
            // read and parse numerical constraints
            var inputLineSplit = Console.ReadLine().Split();

            var n = Convert.ToInt32(inputLineSplit[0]);
            var m = Convert.ToInt32(inputLineSplit[1]);
            var k = Convert.ToInt32(inputLineSplit[2]);

            // build adjacency list
            // O(N + M)
            var adj = new List<int>[n + 1];
            for (int i = 1; i <= n; i++) adj[i] = new List<int>();

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split();

                var u = Convert.ToInt32(edge[0]);
                var v = Convert.ToInt32(edge[1]);

                // undirected graph - add to both lists
                adj[u].Add(v);
                adj[v].Add(u);
            }

            // find all component sizes using iterative dfs
            // O(N + M)
            var componentSizes = new List<int>();
            var visited = new bool[n + 1];

            for (var i = 1; i <= n; i++)
            {
                if (!visited[i])
                {
                    var currentComponentSize = 0;
                    var stack = new Stack<int>();

                    stack.Push(i);
                    visited[i] = true;

                    while (stack.Count > 0)
                    {
                        var u = stack.Pop();
                        currentComponentSize += 1;

                        foreach (int v in adj[u])
                        {
                            if (!visited[v])
                            {
                                visited[v] = true;
                                stack.Push(v);
                            }
                        }
                    }

                    componentSizes.Add(currentComponentSize);
                }
            }

            // greedy selection
            var numToMerge = Math.Min(componentSizes.Count, k + 1);

            var maxSize = componentSizes
                .OrderByDescending(size => size)
                .Take(numToMerge)
                .Select(size => (long) size)
                .Sum();

            Console.WriteLine(maxSize);
        }
    }
}