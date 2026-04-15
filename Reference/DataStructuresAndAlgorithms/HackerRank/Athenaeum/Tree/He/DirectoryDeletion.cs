using System;
using System.Linq;
using System.Collections.Generic;

namespace Athenaeum.Tree.He
{
    public class DirectoryDeletion
    {
        private static List<int>[] children;
        private static HashSet<int> targets;
        private static int minDeletions = 0;

        public static void Main()
        {
            // reading n
            var n = Convert.ToInt32(Console.ReadLine());

            // build adjacency list
            children = new List<int>[n + 1];
            for (var i = 1; i <= n; i++) children[i] = new List<int>();

            string[] parents = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                int p = int.Parse(parents[i]);
                if (p != -1)
                {
                    // i + 1 is the ID of the directory
                    children[p].Add(i + 1);
                }
            }

            // reading m
            var m = Convert.ToInt32(Console.ReadLine());

            // building deletion set
            targets = new HashSet<int>();

            var toDelete = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (var node in toDelete) targets.Add(node);

            // DepthFirstSearch(1);

            DepthFirstSearchIterative(1);

            Console.WriteLine(minDeletions);
        }

        private static void DepthFirstSearch(int u)
        {
            if (targets.Contains(u))
            {
                minDeletions += 1;
                return; // don't recurse, children are dealt with
            }

            foreach (int v in children[u]) DepthFirstSearch(v);
        }

        private static void DepthFirstSearchIterative(int u)
        {
            var stack = new Stack<int>();

            stack.Push(u);

            while (stack.Count > 0)
            {
                int current = stack.Pop();

                if (targets.Contains(current))
                {
                    // if this node is a target, increment and STOP traversal here
                    minDeletions += 1;
                }
                else
                {
                    foreach (int v in children[current]) stack.Push(v);
                }
            }
        }
    }
}