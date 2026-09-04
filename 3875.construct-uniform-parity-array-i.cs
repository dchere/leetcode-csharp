/*
 * @lc app=leetcode id=3875 lang=csharp
 *
 * [3875] Construct Uniform Parity Array I
 *
 * This problem is pretty ironic, because the answer is always true.
 * If the initial array contains only even numbers or only odd numbers -
 * the answer is true.
 * If there is at least one odd number, the answer is true, as it is always
 * possible to build an odd number from an even number and an odd number.
 * If there are two or more odd numbers, the answer is true, as it is always
 * possible to build an even number from two odd numbers.
 * And even more: if there is at least one odd number in the array, you could
 * always make an array of all odd numbers.
 */

// @lc code=start
public class Solution
{
    public bool UniformArray(int[] nums1)
    {
        return true;
    }
}
// @lc code=end

