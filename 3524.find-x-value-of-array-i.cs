/*
 * @lc app=leetcode id=3524 lang=csharp
 *
 * [3524] Find X Value of Array I
 */

// @lc code=start
public class Solution
{
    public long[] ResultArray(int[] nums, int k)
    {
        long[] result = new long[k];
        long[] dp = new long[k];
        foreach (int num in nums)
        {
            int val = num % k;
            long[] nextDp = new long[k];

            nextDp[val]++; // only current element

            // Previous elements plus current
            for (int r = 0; r < k; r++)
                nextDp[r * val % k] += dp[r];

            for (int r = 0; r < k; r++)
                result[r] += nextDp[r];

            dp = nextDp;
        }

        return result;
    }
}
// @lc code=end

