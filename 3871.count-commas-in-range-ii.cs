/*
 * @lc app=leetcode id=3871 lang=csharp
 *
 * [3871] Count Commas in Range II
 */

// @lc code=start

public class Solution
{
    public long CountCommas(long n)
    {
        long res = 0;
        long threshold = 1000;
        while (n >= threshold)
        {
            res += n - threshold + 1;
            threshold *= 1000;
        }
        return res;
    }
}
// @lc code=end

