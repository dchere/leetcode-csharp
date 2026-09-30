/*
 * @lc app=leetcode id=1111 lang=csharp
 *
 * [1111] Maximum Nesting Depth of Two Valid Parentheses Strings
 */

// @lc code=start
public class Solution
{
    public int[] MaxDepthAfterSplit(string seq)
    {
        ReadOnlySpan<char> span = seq.AsSpan();
        int n = span.Length;
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            // separate parentheses to two groups: odd and even 
            result[i] = (span[i] == ')') ? ((i & 1) ^ 1) : (i & 1);
        }

        return result;
    }
}
// @lc code=end

