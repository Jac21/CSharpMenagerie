namespace Athenaeum.Tree
{
    public class SubtreeOfAnotherTree
    {
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null ||
                subRoot == null)
            {
                return false;
            }

            return AreEqual(root, subRoot) || (IsSubtree(root.Left, subRoot) || IsSubtree(root.Right, subRoot));
        }

        private static bool AreEqual(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null) return true;

            if (root == null || subRoot == null || root.Val != subRoot.Val) return false;

            return AreEqual(root.Left, subRoot.Left) && AreEqual(root.Right, subRoot.Right);
        }
    }
}