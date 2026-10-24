/*
 * @lc app=leetcode id=3644 lang=csharp
 *
 * [3644] Maximum K to Sort a Permutation
 */

// @lc code=start
public class Solution
{
    public int SortPermutation(int[] nums)
    {
        int n = nums.Length;
        int k = -1;

        for (int i = 0; i < n; i++)
        {
            // If the element is not in its sorted position, accumulate its value with bitwise AND
            if (nums[i] != i)
                k &= nums[i];
        }

        // If no elements were misplaced (array is already sorted), return 0
        return k == -1 ? 0 : k;
    }
}
// @lc code=end

