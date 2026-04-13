using System;
using System.Collections.Generic;

namespace Athenaeum.Tree.He
{
    /*
     * Minimum Nodes
67% Success
2958 Attempts
20 Points
1s Time Limit
256MB Memory
1024 KB Max Code
You are given a tree with N nodes and each node has some value assigned to it. Now you are given Q tasks of the form X K.
For each task, you have to find the path starting from X such that sum of nodes in the path is at least K and it contains minimum number of nodes. If such path exists, print the count of nodes in the path, else print -1.

Input format

First line: Two space-separated integers N and Q
Second line: N space-separated integers (denoting vali)
Next N -1 lines: Two space-separated integers U and V (denoting an edge between the nodes U and V)
Next Q lines:Two space-separated integers X and K
Output format

For each task, print the required answer in a new line.

Input Constraints







Examples
Input

4 2
2 3 4 5
1 2
2 3
1 4
1 6
2 5
Output

2
2

Explanation
For task 1: There are two paths from 1 .
1->2->4, sum=9
1->4 , sum=7
So path with minimum number of nodes and sum>=6 is 1->4 as it has only two nodes while the other path has three nodes.
For task 2: Paths with minimum number of nodes and sum>=5 are 2->1 and 2->3. The path 2->1->4 has sum=10 but it has three nodes.
     */
    public class MinimumNodes
    {
        public static void Main()
        {
            // 1. Reading N and Q
            var line1 = Console.ReadLine().Split();
            var N = int.Parse(line1[0]);
            var Q = int.Parse(line1[1]);

            // 2. Reading Node Values (1-based)
            var nodeValues = new long[N + 1];
            var valStrings = Console.ReadLine().Split();
            for (var i = 1; i <= N; i++)
            {
                nodeValues[i] = long.Parse(valStrings[i - 1]);
            }

            // 3. Building the Adjacency List
            var adj = new List<int>[N + 1];
            for (var i = 1; i <= N; i++) adj[i] = new List<int>();

            for (var i = 0; i < N - 1; i++)
            {
                var edge = Console.ReadLine().Split();
                var u = int.Parse(edge[0]);
                var v = int.Parse(edge[1]);
                adj[u].Add(v);
                adj[v].Add(u);
            }

            // 4. Processing Queries
            var visited = new bool[N + 1];

            for (var q = 0; q < Q; q++)
            {
                var query = Console.ReadLine().Split();
                var startNode = int.Parse(query[0]);
                var K = long.Parse(query[1]);

                // BFS Logic
                Array.Clear(visited, 0, visited.Length);
                Queue<(int node, long sum, int count)> queue = new Queue<(int, long, int)>();

                queue.Enqueue((startNode, nodeValues[startNode], 1));
                visited[startNode] = true;

                var result = -1;

                while (queue.Count > 0)
                {
                    var (currNode, currSum, currCount) = queue.Dequeue();

                    // Check condition as we pull
                    if (currSum >= K)
                    {
                        result = currCount;
                        break; 
                    }

                    foreach (var neighbor in adj[currNode])
                    {
                        if (!visited[neighbor])
                        {
                            visited[neighbor] = true;
                            queue.Enqueue((neighbor, currSum + nodeValues[neighbor], currCount + 1));
                        }
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}