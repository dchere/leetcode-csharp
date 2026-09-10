/*
 * @lc app=leetcode id=2265 lang=csharp
 *
 * [2265] Count Nodes Equal to Average of Subtree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public int AverageOfSubtree(TreeNode root)
    {
        return DFS(root).Matches;
    }

    private (int Sum, int Count, int Matches) DFS(TreeNode node)
    {
        if (node == null) return (0, 0, 0);
        var (leftSum, leftCount, leftMatches) = DFS(node.left);
        var (rightSum, rightCount, rightMatches) = DFS(node.right);
        int sum = node.val + leftSum + rightSum;
        int count = 1 + leftCount + rightCount;
        int matches = leftMatches + rightMatches;
        if (sum / count == node.val) matches++;
        return (sum, count, matches);
    }
}
// @lc code=end

