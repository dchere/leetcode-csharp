/*
 * @lc app=leetcode id=1526 lang=csharp
 *
 * [1526] Minimum Number of Increments on Subarrays to Form a Target Array
 */

// @lc code=start
public class Solution
{
    public int MinNumberOperations(int[] target)
    {
        // convert to ReadOnlySpan to eliminate JIT array bounds checks
        ReadOnlySpan<int> span = target;
        // we always need number of operations that is equal to the first element
        int operations = span[0];
        int n = span.Length;
        // 2. Linear scan using branchless arithmetic
        for (int i = 1; i < n; i++)
        {
            int diff = span[i] - span[i - 1];
            // if the current element is more than previous, than we add to add the difference
            if (diff > 0)
                operations += diff;
            // else everything is already done
        }

        return operations;
    }
}
// @lc code=end

