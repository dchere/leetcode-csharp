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
        int minElement = nums1[0];
        bool hasOdd = minElement % 2 != 0;
        for (int i = 1; i < nums1.Length; i++)
        {
            if (!hasOdd && nums1[i] % 2 != 0) hasOdd = true;
            if (nums1[i] < minElement) minElement = nums1[i];
        }
        if (!hasOdd) return true; // all elements are even numbers
        /*
         * If the smallest element is an even number, and an odd number is
         * present, then the array cannot be made into all-odd or all-even array 
         */
        if (minElement % 2 == 0) return false;
        return true;
    }
}
// @lc code=end

