/*
 * @lc app=leetcode id=3903 lang=csharp
 *
 * [3903] Smallest Stable Index I
 */

// @lc code=start
public class Solution
{

    /*
     * Returns the index of the rightmost minimum element of the subarray.
     */
    private int IndexFarthestMinElement(int[] nums, int from)
    {
        int index = nums.Length - 1;
        for (int i = nums.Length - 1; i >= from; i--)
        {
            if (nums[i] < nums[index]) index = i;
        }
        return index;
    }
    public int FirstStableIndex(int[] nums, int k)
    {
        int maxElement = nums[0];
        int indexMinElement = IndexFarthestMinElement(nums, 0);
        for (int i = 0; i < nums.Length; i++)
        {
            /*
             * Potential O(n^2) is fine here, as the array is up to 100 elements.
             * We minimize rescan calls by searching for the rightmost index.
             * This solution does not allocate extra memory.
             */
            if (indexMinElement < i) indexMinElement = IndexFarthestMinElement(nums, i);
            if (nums[i] > maxElement) maxElement = nums[i];
            if (maxElement - nums[indexMinElement] <= k) return i;
        }
        return -1;
    }
}
// @lc code=end

