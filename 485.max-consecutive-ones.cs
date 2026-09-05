/*
 * @lc app=leetcode id=485 lang=csharp
 *
 * [485] Max Consecutive Ones
 */

// @lc code=start

public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int cur = 0;
        int res = 0;
        foreach (int num in nums)
        {
            if (num == 1)
            {
                cur++;
            }
            else
            {
                if (cur > res) res = cur;
                cur = 0;
            }
        }
        if (cur > res) res = cur; // to handle the array that ends with 1
        return res;
    }
}
// @lc code=end

