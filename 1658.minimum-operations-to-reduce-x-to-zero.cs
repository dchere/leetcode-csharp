/*
 * @lc app=leetcode id=1658 lang=csharp
 *
 * [1658] Minimum Operations to Reduce X to Zero
 */

// @lc code=start
public class Solution
{
    public int MinOperations(int[] nums, int x)
    {
        int sum = 0;
        foreach (int num in nums) sum += num;

        int target = sum - x;

        // Sum of all array's elements less than x
        if (target < 0) return -1;

        int n = nums.Length;

        // We need to remove all elements, as sum of array equal to x
        if (target == 0) return n;

        int left = 0;
        int currentSum = 0;
        int maxLen = -1;
        for (int right = 0; right < n; right++)
        {
            currentSum += nums[right];

            while (currentSum > target)
                currentSum -= nums[left++];

            if (currentSum == target)
                maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen == -1 ? -1 : n - maxLen;
    }
}
// @lc code=end

