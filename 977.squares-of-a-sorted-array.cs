/*
 * @lc app=leetcode id=977 lang=csharp
 *
 * [977] Squares of a Sorted Array
 */

// @lc code=start
public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        int[] res = new int[nums.Length];
        int l = 0;
        int lSquare = nums[l] * nums[l];
        int r = nums.Length - 1;
        int rSquare = nums[r] * nums[r];
        int i = r;
        while (l <= r)
        {
            if (lSquare > rSquare)
            {
                res[i--] = lSquare;
                l++;
                if (l <= r) lSquare = nums[l] * nums[l];
            }
            else
            {
                res[i--] = rSquare;
                r--;
                if (l <= r) rSquare = nums[r] * nums[r];
            }
        }
        return res;
    }
}
// @lc code=end

