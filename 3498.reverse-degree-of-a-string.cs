/*
 * @lc app=leetcode id=3498 lang=csharp
 *
 * [3498] Reverse Degree of a String
 */

// @lc code=start
public class Solution
{
    public int ReverseDegree(string s)
    {
        int res = 0;
        for (int i = 0; i < s.Length; i++)
            res += (26 - s[i] + 'a') * (i + 1);
        return res;
    }
}
// @lc code=end

