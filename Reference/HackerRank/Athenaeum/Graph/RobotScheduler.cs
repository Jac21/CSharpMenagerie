using System.Collections.Generic;

namespace Athenaeum.Graph
{
    public static class RobotScheduler
    {
        public static bool CanSchedule(int components, int[][] schedule)
        {
            if (components == 0 || schedule.Length == 0) return false;

            var graph = new List<int>[components];

            for (var i = 0; i < components; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in schedule)
            {
                graph[edge[0]].Add(edge[1]);
            }

            var visitedNodes = new int[components];

            // 0 for unvisited, 1 for processed, 2 for processing
            for (var i = 0; i < components; i++)
            {
                if (visitedNodes[i] == 0 && IsCyclic(graph, visitedNodes, i))
                {
                    return false;
                }
            }

            return true;

            bool IsCyclic(IReadOnlyList<List<int>> graphList, int[] visited, int current)
            {
                if (visited[current] == 2) return true;

                visited[current] = 2;

                foreach (var node in graphList[current])
                {
                    if (visited[node] != 1 && IsCyclic(graphList, visited, node))
                    {
                        return true;
                    }
                }

                visited[current] = 1;
                return false;
            }
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Topological_sorting
        /// </summary>
        /// <param name="components"></param>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public static bool CanScheduleKahn(int components, int[][] schedule)
        {
            if (components == 0 || schedule.Length == 0) return false;

            var graph = new List<int>[components];

            var degree = new int[components];

            foreach (var pair in schedule)
            {
                graph[pair[0]] ??= new List<int>();
                graph[pair[0]].Add(pair[1]);
                degree[pair[1]] += 1;
            }

            var queue = new Queue<int>();

            for (int i = 0; i < components; i++)
            {
                if (degree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            int count = 0;

            while (queue.TryDequeue(out var node))
            {
                if (graph[node] != null)
                {
                    foreach (var c in graph[node])
                    {
                        if (--degree[c] == 0)
                        {
                            queue.Enqueue(c);
                        }
                    }
                }

                count += 1;
            }

            return count == components;
        }
    }
}