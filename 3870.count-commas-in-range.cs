/*
 * @lc app=leetcode id=3870 lang=csharp
 *
 * [3870] Count Commas in Range
 */

// @lc code=start

public class Solution
{
    public int CountCommas(int n)
    {
        return n >= 1000 ? n - 999 : 0;
    }
}
// @lc code=end

