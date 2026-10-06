/*
 * @lc app=leetcode id=32 lang=csharp
 *
 * [32] Longest Valid Parentheses
 */

// @lc code=start
public class Solution
{
    public int LongestValidParentheses(string s)
    {
        ReadOnlySpan<char> span = s.AsSpan();
        int n = span.Length;
        if (n < 2) return 0;

        int maxLen = 0;
        int left = 0, right = 0;

        for (int i = 0; i < n; i++)
        {
            if (span[i] == '(')
                left++;
            else
                right++;

            if (left == right)
            {
                int len = right << 1; // instead of *2
                if (len > maxLen) maxLen = len;
            }
            else if (right > left)
            {
                left = 0;
                right = 0;
            }
        }

        left = 0;
        right = 0;

        // backward propagation
        for (int i = n - 1; i >= 0; i--)
        {
            if (span[i] == '(') left++;
            else right++;

            if (left == right)
            {
                int len = right << 1;
                if (len > maxLen) maxLen = len;
            }
            else if (left > right)
            {
                left = 0;
                right = 0;
            }
        }
        return maxLen;
    }
}
// @lc code=end

