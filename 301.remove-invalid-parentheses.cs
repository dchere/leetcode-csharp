/*
 * @lc app=leetcode id=301 lang=csharp
 *
 * [301] Remove Invalid Parentheses
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution
{
    public IList<string> RemoveInvalidParentheses(string s)
    {
        int remL = 0, remR = 0;

        foreach (char ch in s)
        {
            if (ch == '(')
            {
                remL++;
            }
            else if (ch == ')')
            {
                if (remL > 0)
                {
                    remL--;
                }
                else
                {
                    remR++;
                }
            }
        }

        var result = new List<string>();
        Span<char> current = stackalloc char[s.Length];

        Dfs(s.AsSpan(), 0, 0, 0, remL, remR, current, result);
        return result;
    }

    private void Dfs(
        ReadOnlySpan<char> s,
        int index,
        int len,
        int bal,
        int remL,
        int remR,
        Span<char> current,
        List<string> result)
    {
        if (bal < 0) return;

        if (index == s.Length)
        {
            if (remL == 0 && remR == 0 && bal == 0)
                result.Add(new string(current.Slice(0, len)));
            return;
        }

        char c = s[index];

        if (c == '(' && remL > 0)
        {
            Dfs(s, index + 1, len, bal, remL - 1, remR, current, result);
        }
        else if (c == ')' && remR > 0)
        {
            Dfs(s, index + 1, len, bal, remL, remR - 1, current, result);
        }

        current[len] = c;
        int nextBal = bal + (c == '(' ? 1 : (c == ')' ? -1 : 0));

        int i = index + 1;
        if (c == '(' || c == ')')
        {
            while (i < s.Length && s[i] == c)
            {
                current[len + (i - index)] = c;
                nextBal += (c == '(' ? 1 : -1);
                i++;
            }
        }

        Dfs(s, i, len + (i - index), nextBal, remL, remR, current, result);
    }
}
// @lc code=end