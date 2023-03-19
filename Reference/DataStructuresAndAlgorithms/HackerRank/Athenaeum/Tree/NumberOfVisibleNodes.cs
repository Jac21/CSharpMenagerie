using System.Collections.Generic;

namespace Athenaeum.Tree
{
    public static class NumberOfVisibleNodes

    {
        public static int VisibleNodes(TreeNode root)
        {
            if (root == null) return 0;

            var result = 0;

            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var level = queue.Count;

                while (level > 0)
                {
                    var current = queue.Dequeue();

                    if (current.Left != null) queue.Enqueue(current.Left);

                    if (current.Right != null) queue.Enqueue(current.Right);

                    if (level == 1) result += 1;

                    level -= 1;
                }
            }

            return result;
        }
    }
}