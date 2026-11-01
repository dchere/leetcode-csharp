/*
 * @lc app=leetcode id=453 lang=csharp
 *
 * [453] Minimum Moves to Equal Array Elements
 */

// @lc code=start
public class Solution
{
    public int MinMoves(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
            return 0;
        long sum = nums[0]; // Using 64-bit int to prevent overflow during sum accumulation
        int minVal = nums[0];

        for (int i = 1; i < n; i++)
        {
            if (nums[i] < minVal)
                minVal = nums[i];
            sum += nums[i];
        }

        return (int)(sum - (long)n * minVal);
    }
}
// @lc code=end


