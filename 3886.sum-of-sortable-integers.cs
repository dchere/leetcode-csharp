/*
 * @lc app=leetcode id=3886 lang=csharp
 *
 * [3886] Sum of Sortable Integers
 */

// @lc code=start
public class Solution
{
    public int SortableIntegers(int[] nums)
    {
        int n = nums.Length;
        int totalSum = 0;

        for (int k = 1; k <= n; k++)
        {
            if (n % k != 0)
                continue;

            if (IsSortable(nums, n, k))
                totalSum += k;
        }

        return totalSum;
    }

    private static bool IsSortable(int[] nums, int n, int k)
    {
        int numBlocks = n / k;
        int prevBlockMax = int.MinValue;

        for (int b = 0; b < numBlocks; b++)
        {
            int offset = b * k;

            int blockMin = nums[offset];
            int blockMax = nums[offset];
            int drops = 0;

            for (int i = 0; i < k; i++)
            {
                int curr = nums[offset + i];
                int next = nums[offset + (i + 1) % k];

                if (curr > blockMax)
                    blockMax = curr;
                if (curr < blockMin)
                    blockMin = curr;

                if (curr > next)
                    drops++;
            }

            if (drops > 1)
                return false;

            if (blockMin < prevBlockMax)
                return false;

            prevBlockMax = blockMax;
        }

        return true;
    }
}
// @lc code=end

