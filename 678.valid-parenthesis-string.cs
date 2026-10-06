/*
 * @lc app=leetcode id=678 lang=csharp
 *
 * [678] Valid Parenthesis String
 */

// @lc code=start

public class Solution
{
    public bool CheckValidString(string s)
    {
        int minOpen = 0;
        int maxOpen = 0;

        foreach (char ch in s)
        {
            if (ch == '(')
            {
                minOpen++;
                maxOpen++;
            }
            else if (ch == ')')
            {
                minOpen--;
                maxOpen--;
            }
            else // ch == '*'
            {
                minOpen--;
                maxOpen++;
            }

            if (maxOpen < 0) return false;
            if (minOpen < 0) minOpen = 0;
        }

        return minOpen == 0;
    }
}
// @lc code=end