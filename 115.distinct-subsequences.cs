/*
 * @lc app=leetcode id=115 lang=csharp
 *
 * [115] Distinct Subsequences
 */

// @lc code=start

public class Solution
{
    public int NumDistinct(string s, string t)
    {
        int m = s.Length;
        int n = t.Length;
        if (m < n) return 0;
        int[] dp = new int[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= m; i++)
        {
            for (int j = Math.Min(i, n); j > 0; j--)
            {
                if (s[i - 1] == t[j - 1]) dp[j] += dp[j - 1];
            }
        }
        return dp[n];
    }
}
// @lc code=end

