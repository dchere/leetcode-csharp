/*
 * @lc app=leetcode id=1295 lang=csharp
 *
 * [1295] Find Numbers with Even Number of Digits
 *
 * Constraints are 1 <= nums[i] <= 10^5, so even digit counts are exactly:
 * 2 digits: 10..99
 * 4 digits: 1000..9999
 * 6 digits: 100 000
 * and no value larger than 100,000 can appear.
 */

// @lc code=start

public class Solution
{
    public int FindNumbers(int[] nums)
    {
        int res = 0;
        foreach (int num in nums)
        {
            if ((num > 9 && num < 100) || (num > 999 && num < 10_000) || (num == 100_000)) res++;
        }
        return res;
    }
}
// @lc code=end

