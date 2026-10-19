/*
 * @lc app=leetcode id=1021 lang=csharp
 *
 * [1021] Remove Outermost Parentheses
 */

// @lc code=start
public class Solution
{
    public string RemoveOuterParentheses(string s)
    {
        ReadOnlySpan<char> span = s.AsSpan();
        int n = span.Length;

        int len = 0;
        int depth = 0;
        for (int i = 0; i < n; i++)
        {
            if (span[i] == '(')
            {
                if (depth > 0) len++;
                depth++;
            }
            else
            {
                depth--;
                if (depth > 0) len++;
            }
        }

        if (len == 0) return string.Empty;

        return string.Create(len, s, (buffer, str) =>
        {
            ReadOnlySpan<char> src = str.AsSpan();
            int writeIndex = 0;
            int d = 0;

            for (int i = 0; i < src.Length; i++)
            {
                char c = src[i];
                if (c == '(')
                {
                    if (d > 0) buffer[writeIndex++] = '(';
                    d++;
                }
                else
                {
                    d--;
                    if (d > 0) buffer[writeIndex++] = ')';
                }
            }
        });
    }
}
// @lc code=end

