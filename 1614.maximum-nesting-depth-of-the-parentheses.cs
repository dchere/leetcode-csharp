/*
 * @lc app=leetcode id=1614 lang=csharp
 *
 * [1614] Maximum Nesting Depth of the Parentheses
 */

// @lc code=start
public class Solution
{
    public int MaxDepth(string s)
    {
        int depth = 0;
        int maxDepth = 0;
        foreach (char ch in s)
        {
            if (ch == '(')
                depth++;
            else if (ch == ')')
                maxDepth = Math.Max(maxDepth, depth--);
        }
        return maxDepth;
    }
}
// @lc code=end

