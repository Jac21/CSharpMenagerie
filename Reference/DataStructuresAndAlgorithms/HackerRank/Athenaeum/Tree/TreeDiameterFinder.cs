using System;

namespace Athenaeum.Tree
{
    public class Height
    {
        public int H;
    }

    public class TreeDiameterFinder
    {
        /// <summary>
        /// O(N)
        /// O(N) for recursive call stack
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int Diameter(TreeNode node)
        {
            return node == null ? 0 : Diameter(node, new Height());
        }

        private static int Diameter(TreeNode node, Height height)
        {
            var leftHeight = new Height();
            var rightHeight = new Height();

            if (node == null)
            {
                height.H = 0;
                return 0;
            }

            var leftDiameter = Diameter(node.Left, leftHeight);
            var rightDiameter = Diameter(node.Right, rightHeight);

            height.H = Math.Max(leftHeight.H, rightHeight.H) + 1;

            return Math.Max(leftHeight.H + rightHeight.H + 1, Math.Max(leftDiameter, rightDiameter));
        }
    }
}