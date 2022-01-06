using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    // Definition for a Node.
    public class Node
    {
        public int Val;
        public readonly IList<Node> Neighbors;

        public Node()
        {
            Val = 0;
            Neighbors = new List<Node>();
        }

        public Node(int val)
        {
            Val = val;
            Neighbors = new List<Node>();
        }

        public Node(int val, IList<Node> _neighbors)
        {
            Val = val;
            Neighbors = _neighbors;
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
            if (map.ContainsKey(node.Val)) return null;

            var nodeToReturn = new Node
            {
                Val = node.Val
            };

            map[node.Val] = nodeToReturn;

            foreach (var neighbor in node.Neighbors)
            {
                if (map.ContainsKey(neighbor.Val))
                {
                    nodeToReturn.Neighbors.Add(map[neighbor.Val]);
                }
                else
                {
                    nodeToReturn.Neighbors.Add(CloneDfs(neighbor, map));
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

            var startNode = new Node(node.Val);
            map.Add(startNode.Val, startNode);

            while (queue.Any())
            {
                var item = queue.Dequeue();

                foreach (var neighbor in item.Neighbors)
                {
                    if (map.ContainsKey(neighbor.Val))
                    {
                        map[neighbor.Val].Neighbors.Add(map[neighbor.Val]);
                    }
                    else
                    {
                        var newNode = new Node(neighbor.Val);

                        map.Add(neighbor.Val, newNode);

                        map[item.Val].Neighbors.Add(newNode);

                        queue.Enqueue(neighbor);
                    }
                }
            }

            return startNode;
        }
    }
}