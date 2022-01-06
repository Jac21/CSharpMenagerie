using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public static class GraphCloner
    {
        public static Node? CloneGraph(Node node)
        {
            if (node == null) return null;

            var map = new Dictionary<int, Node>();

            return CloneDfs(node, map);
        }

        public static Node CloneDfs(Node node, Dictionary<int, Node> map)
        {
            if (map.ContainsKey(node.val)) return null;

            var nodeToReturn = new Node
            {
                val = node.val
            };

            map[node.val] = nodeToReturn;

            foreach (var neighbor in node.neighbors)
            {
                if (map.ContainsKey(neighbor.val))
                {
                    nodeToReturn.neighbors.Add(map[neighbor.val]);
                }
                else
                {
                    nodeToReturn.neighbors.Add(CloneDfs(neighbor, map));
                }
            }

            return nodeToReturn;
        }

        public static Node? CloneBfs(Node node)
        {
            if (node == null) return null;

            var map = new Dictionary<int, Node>();

            var queue = new Queue<Node>();

            queue.Enqueue(node);

            var startNode = new Node(node.val);
            map.Add(startNode.val, startNode);

            while (queue.Any())
            {
                var item = queue.Dequeue();

                foreach (var neighbor in item.neighbors)
                {
                    if (map.ContainsKey(neighbor.val))
                    {
                        map[neighbor.val].neighbors.Add(map[neighbor.val]);
                    }
                    else
                    {
                        var newNode = new Node(neighbor.val);

                        map.Add(neighbor.val, newNode);

                        map[item.val].neighbors.Add(newNode);

                        queue.Enqueue(neighbor);
                    }
                }
            }

            return startNode;
        }
    }
}

