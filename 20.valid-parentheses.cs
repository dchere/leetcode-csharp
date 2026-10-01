/*
 * @lc app=leetcode id=20 lang=csharp
 *
 * [20] Valid Parentheses
 */

// @lc code=start
public class Solution
{
    public bool IsValid(string s)
    {
        int n = s.Length;
        if (n % 2 != 0) return false;
        int halfN = n / 2;
        char[] openBrackets = new char[halfN];
        int nOpenBrackets = 0;
        foreach (char ch in s)
        {
            if (ch == '(' || ch == '{' || ch == '[')
            {
                if (nOpenBrackets >= halfN) return false;
                openBrackets[nOpenBrackets++] = ch;
            }
            else
            {
                if (nOpenBrackets == 0) return false;
                char openBracket = openBrackets[--nOpenBrackets];
                if (ch == ')' && openBracket != '(')
                    return false;
                else if (ch == '}' && openBracket != '{')
                    return false;
                else if (ch == ']' && openBracket != '[')
                    return false;
            }
        }
        return nOpenBrackets == 0;
    }
}
// @lc code=end

