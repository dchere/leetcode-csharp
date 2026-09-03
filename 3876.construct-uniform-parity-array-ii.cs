/*
 * @lc app=leetcode id=3876 lang=csharp
 *
 * [3876] Construct Uniform Parity Array II
 */

// @lc code=start

public class Solution
{
    public bool UniformArray(int[] nums1)
    {
        Array.Sort(nums1); // to check only elements before the current
        bool allEven = true;
        bool allOdd = true;
        bool isOdd;
        for (int i = 0; i < nums1.Length; i++)
        {
            isOdd = nums1[i] % 2 == 1;
            if (allEven && isOdd) allEven = false;
            if (allOdd && !isOdd && i == 0) allOdd = false;
            if (!(allEven||allOdd)) return false;
        }
        return true;
    }
}
// @lc code=end

