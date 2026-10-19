/*
 * @lc app=leetcode id=2333 lang=csharp
 *
 * [2333] Minimum Sum of Squared Difference
 */

// @lc code=start
using System;

public class Solution
{
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        int k = k1 + k2;
        int n = nums1.Length;
        int[] count = new int[100001];
        int maxDiff = 0;

        for (int i = 0; i < n; i++)
        {
            int diff = Math.Abs(nums1[i] - nums2[i]);
            count[diff]++;
            if (diff > maxDiff) maxDiff = diff;
        }

        for (int v = maxDiff; v > 0 && k > 0; v--)
        {
            if (count[v] == 0) continue;

            int take = Math.Min(count[v], k);
            count[v] -= take;
            count[v - 1] += take;
            k -= take;
        }

        long sum = 0;
        for (long v = 1; v <= maxDiff; v++)
        {
            if (count[v] <= 0)
                continue;
            sum += count[v] * v * v;
        }

        return sum;
    }
}
// @lc code=end