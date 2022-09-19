using System.Collections.Generic;

namespace Athenaeum.Tree
{
    public class SerializeAndDeserializeBinaryTree
    {
        // Encodes a tree to a single string.
        public Queue<int> serialize(TreeNode root)
        {
            var q = new Queue<int>();
            
            SerializeTree(root, q);
            
            return q;
        }

        private static void SerializeTree(TreeNode root, Queue<int> queue)
        {
            if (root == null)
            {
                queue.Enqueue(int.MinValue);
                return;
            }
            
            queue.Enqueue(root.Val);
            SerializeTree(root.Left, queue);
            SerializeTree(root.Right, queue);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(Queue<int> data)
        {
            if (data.Count <= 0) return null;

            var rootValue = data.Dequeue();
            if (rootValue == int.MinValue) return null;

            var root = new TreeNode(rootValue)
            {
                Left = deserialize(data),
                Right = deserialize(data)
            };

            return root;
        }
    }
}