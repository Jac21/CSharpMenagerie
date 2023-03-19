using System.Collections.Generic;

namespace Athenaeum.Tree
{
    public static class InvertBinaryTree
    {
        public static TreeNode InvertTreeDfs(TreeNode root)
        {
            if (root == null) return null;

            InvertTreeDfs(root.Left);
            InvertTreeDfs(root.Right);

            (root.Left, root.Right) = (root.Right, root.Left);

            return root;
        }

        public static TreeNode InvertTreeBfs(TreeNode root)
        {
            if (root == null) return null;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                (currentNode.Left, currentNode.Right) = (currentNode.Right, currentNode.Left);

                if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
            }

            return root;
        }
    }
}