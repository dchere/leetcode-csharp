/*
 * @lc app=leetcode id=3942 lang=csharp
 *
 * [3942] Minimum Operations to Sort a Permutation
 */

// @lc code=start
using System;

public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        if (n == 1) return 0;

        // 1. Find the index of element 0
        int pos0 = -1;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                pos0 = i;
                break;
            }
        }

        // 2. Check if the array is cyclically increasing
        bool isIncreasing = true;
        for (int i = 0; i < n - 1; i++)
        {
            if ((nums[i] + 1) % n != nums[i + 1])
            {
                isIncreasing = false;
                break;
            }
        }

        if (isIncreasing)
        {
            // Left rotations vs Simulated Right rotations
            return Math.Min(pos0, n - pos0 + 2);
        }

        // 3. Check if the array is cyclically decreasing
        bool isDecreasing = true;
        for (int i = 0; i < n - 1; i++)
        {
            if ((nums[i] - 1 + n) % n != nums[i + 1])
            {
                isDecreasing = false;
                break;
            }
        }

        if (isDecreasing)
        {
            // Rotate left then Reverse vs Reverse then Rotate left
            return Math.Min(pos0 + 2, n - pos0);
        }

        return -1;
    }
}
// @lc code=end

