/*
 * @lc app=leetcode id=1190 lang=csharp
 *
 * [1190] Reverse Substrings Between Each Pair of Parentheses
 */

// @lc code=start

public class Solution
{
    public string ReverseParentheses(string s)
    {
        int n = s.Length;
        int[] pair = new int[n];
        int[] stack = new int[n];
        int top = 0;

        int parenthesesCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '(')
            {
                stack[top++] = i;
                parenthesesCount++;
            }
            else if (s[i] == ')')
            {
                int openIdx = stack[--top];
                pair[i] = openIdx;
                pair[openIdx] = i;
            }
        }

        int resLength = n - 2 * parenthesesCount;
        if (resLength <= 0) return string.Empty;

        return string.Create(resLength, (s, pair), static (dest, state) =>
        {
            var (str, p) = state;
            int destIdx = 0;
            int currIdx = 0;
            int direction = 1;

            while (currIdx < str.Length)
            {
                if (str[currIdx] == '(' || str[currIdx] == ')')
                {
                    currIdx = p[currIdx];
                    direction = -direction;
                }
                else
                {
                    dest[destIdx++] = str[currIdx];
                }

                currIdx += direction;
            }
        });
    }
}
// @lc code=end

