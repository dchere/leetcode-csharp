/*
 * @lc app=leetcode id=3727 lang=csharp
 *
 * [3727] Maximum Alternating Sum of Squares
 */

// @lc code=start
using System;

public class Solution
{
    public long MaxAlternatingSum(int[] nums)
    {
        int n = nums.Length;
        Span<long> count = stackalloc long[40001];

        for (int i = 0; i < n; i++)
            if (nums[i] < 0)
                count[-nums[i]]++;
            else
                count[nums[i]]++;

        long sum = 0;
        long nPositiv = (n + 1) / 2;

        for (int v = 40000; v >= 0 && nPositiv > 0; v--)
        {
            if (count[v] == 0) continue;

            long take = Math.Min(count[v], nPositiv);
            sum += take * v * v;
            count[v] -= take;
            nPositiv -= take;
        }

        for (int v = 0; v <= 40000; v++)
            if (count[v] > 0)
                sum -= count[v] * v * v;

        return sum;
    }
}
// @lc code=end

