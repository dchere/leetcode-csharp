/*
 * @lc app=leetcode id=1541 lang=csharp
 *
 * [1541] Minimum Insertions to Balance a Parentheses String
 */

// @lc code=start
public class Solution
{
    public int MinInsertions(string s)
    {
        int insertions = 0;
        int needed = 0;

        foreach (char ch in s)
        {
            if (ch == '(')
            {
                if ((needed & 1) != 0) // instead of %2
                {
                    insertions++;
                    needed--;
                }
                needed += 2;
            }
            else
            {
                needed--;
                if (needed < 0)
                {
                    insertions++;
                    needed += 2;
                }
            }
        }
        return insertions + needed;
    }
}
// @lc code=end

