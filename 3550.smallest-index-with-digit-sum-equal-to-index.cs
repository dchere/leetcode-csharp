/*
 * @lc app=leetcode id=3550 lang=csharp
 *
 * [3550] Smallest Index With Digit Sum Equal to Index
 */

// @lc code=start
public class Solution
{
    public int SmallestIndex(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
                if (sum > i) break;
            }
            if (sum == i) return i;
        }
        return -1;
    }
}
// @lc code=end

