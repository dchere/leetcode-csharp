/*
 * @lc app=leetcode id=856 lang=csharp
 *
 * [856] Score of Parentheses
 */

// @lc code=start
public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        int depth = 0;
        int res = 0;
        bool isPrevChOpen = false; // init value will be overwtitten 
        foreach (char ch in s)
        {
            if (ch == '(')
            {
                depth++;
                isPrevChOpen = true;
            }
            else
            {
                depth--;
                if (isPrevChOpen) res += 1 << depth;
                isPrevChOpen = false;
            }
        }
        return res;
    }
}
// @lc code=end

