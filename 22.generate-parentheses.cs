/*
 * @lc app=leetcode id=22 lang=csharp
 *
 * [22] Generate Parentheses
 */

// @lc code=start
public class Solution
{

    // Number of result strings is the nth Catalan number
    // Since n <= 8, the numbers are hardcoded
    private static readonly int[] CatalanNumbers = [1, 2, 5, 14, 42, 132, 429, 1430];

    public IList<string> GenerateParenthesis(int n)
    {
        string[] result = new string[CatalanNumbers[n - 1]];

        Span<char> current = stackalloc char[2 * n];
        int resultIndex = 0;
        Backtrack(result, ref resultIndex, current, 0, 0, 0, n);

        return result;
    }

    private void Backtrack(string[] result, ref int resultIndex, Span<char> current, int index, int open, int close, int n)
    {
        if (index == 2 * n)
        {
            result[resultIndex++] = new string(current);
            return;
        }

        if (open < n)
        {
            current[index] = '(';
            Backtrack(result, ref resultIndex, current, index + 1, open + 1, close, n);
        }

        if (close < open)
        {
            current[index] = ')';
            Backtrack(result, ref resultIndex, current, index + 1, open, close + 1, n);
        }
    }
}
// @lc code=end

