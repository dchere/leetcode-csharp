/*
 * @lc app=leetcode id=3904 lang=csharp
 *
 * [3904] Smallest Stable Index II
 */

// @lc code=start
public class Solution
{
    public int FirstStableIndex(int[] nums, int k)
    {
        int[] rightMins = (int[])nums.Clone();
        for (int i = rightMins.Length - 2; i >= 0; i--)
        {
            if (rightMins[i] > rightMins[i + 1]) rightMins[i] = rightMins[i + 1];
        }
        int max = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max) max = nums[i];
            if (max - rightMins[i] <= k) return i;
        }
        return -1;
    }
}
// @lc code=end

