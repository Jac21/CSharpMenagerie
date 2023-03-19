using System.Collections.Generic;
using System.Linq;

namespace Athenaeum.Graph
{
    public static class CourseScheduler
    {
        /// <summary>
        /// O(N * P)
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var graph = new List<int>[numCourses];

            // instantiate list for all indices
            for (var i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            // create adjacency list
            foreach (var edge in prerequisites)
            {
                graph[edge[0]].Add(edge[1]);
            }

            // array to keep track of visited nodes
            var visited = new int[numCourses];

            // color coding used 0 for unvisited, 2 for under processing, 1 for processed
            for (var i = 0; i < numCourses; i++)
            {
                if (visited[i] == 0 && IsCyclic(graph, visited, i))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsCyclic(List<int>[] graph, int[] visited, int current)
        {
            // any node which is still under process and is found again in DFS
            // means a cycle exists
            if (visited[current] == 2) return true;

            // mark as under processing
            visited[current] = 2;

            // DFS
            foreach (var node in graph[current])
            {
                if (visited[node] != 1 && IsCyclic(graph, visited, node))
                {
                    return true;
                }
            }

            // processed, no cycle detected thus far
            visited[current] = 1;
            return false;
        }
    }
}