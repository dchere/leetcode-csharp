/*
 * @lc app=leetcode id=940 lang=csharp
 *
 * [940] Distinct Subsequences II
 */

// @lc code=start

public class Solution
{
    const int MOD = 1_000_000_007;
    public int DistinctSubseqII(string s)
    {
        return true ? DistinctSubseqByLastChar(s) : DistinctSubseqByFullSum(s);
    }
    /*
     * Running total and last contribution per letter.
     */
    private int DistinctSubseqByLastChar(string s)
    {
        int[] charContributions = new int[26];
        int total = 0;
        foreach (char ch in s)
        {
            int idx = ch - 'a';
            int countNewSubs = (1 + total - charContributions[idx] + MOD) % MOD;
            charContributions[idx] = (1 + total) % MOD;
            total = (total + countNewSubs) % MOD;
        }
        return total;
    }

    static int SumSubsequences(int[] dp, int initValue = 0)
    {
        int res = initValue;
        foreach (int p in dp) res = (res + p) % MOD;
        return res;
    }

    /*
     * All current subsequences plus current letter,
     * replacing old ones that ended with current letter.
     */
    private int DistinctSubseqByFullSum(string s)
    {
        int[] dp = new int[26];
        foreach (char ch in s)
        {
            int idx = ch - 'a';
            dp[idx] = SumSubsequences(dp, 1); // initValue=1 counts the one-character subsequence itself
        }
        return SumSubsequences(dp);
    }
}
// @lc code=end

