/*
 * @lc app=leetcode id=921 lang=csharp
 *
 * [921] Minimum Add to Make Parentheses Valid
 */

// @lc code=start

public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        int depth = 0;
        int fixers = 0;
        foreach (char ch in s)
        {
            if (ch == '(')
                depth++;
            else if (depth > 0)
                depth--;
            else
                fixers++;
        }
        return depth + fixers;
    }
}
// @lc code=end

