/*
 * @lc app=leetcode id=2913 lang=csharp
 *
 * [2913] Subarrays Distinct Element Sum of Squares I
 */

// @lc code=start
public class Solution
{
    public int SumCounts(IList<int> nums)
    {
        int n = nums.Count;
        int totalSum = 0;

        Span<bool> visited = stackalloc bool[101];

        for (int i = 0; i < n; i++)
        {
            visited.Clear();
            int distinctCount = 0;

            for (int j = i; j < n; j++)
            {
                int val = nums[j];
                if (!visited[val])
                {
                    visited[val] = true;
                    distinctCount++;
                }

                totalSum += distinctCount * distinctCount;
            }
        }

        return totalSum;
    }
}
// @lc code=end

