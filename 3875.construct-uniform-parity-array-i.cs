/*
 * @lc app=leetcode id=3875 lang=csharp
 *
 * [3875] Construct Uniform Parity Array I
 *
 * This problem is pretty ironic.
 * If the initial array contains only even or only odd numbers - the answer is true.
 * If there is at least one odd number - the answer is true, as it is always
 * possible to build an odd number from an even and an odd.
 * If there two and more odd numbers - the answer is true, as it is always
 * possible to build an even number from two odd numbers. 
 */

// @lc code=start
public class Solution {
    public bool UniformArray(int[] nums1) {
        return true;
    }
}
// @lc code=end

