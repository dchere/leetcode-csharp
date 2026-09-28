/*
 * @lc app=leetcode id=859 lang=csharp
 *
 * [859] Buddy Strings
 */

// @lc code=start

public class Solution
{
    public bool BuddyStrings(string s, string goal)
    {
        if (s.Length != goal.Length) return false;

        ReadOnlySpan<char> ss = s.AsSpan();
        ReadOnlySpan<char> gs = goal.AsSpan();
        int n = ss.Length;

        int first = -1, second = -1;
        int mask = 0;
        bool hasDuplicate = false;

        for (int i = 0; i < n; i++)
        {
            if (ss[i] != gs[i])
            {
                if (first == -1) first = i;
                else if (second == -1) second = i;
                else return false; // early exit on 3rd difference!
            }
            else if (!hasDuplicate)
            {
                int bit = 1 << (ss[i] - 'a');
                if ((mask & bit) != 0) hasDuplicate = true;
                else mask |= bit;
            }
        }

        // strings are equal -> need at least 1 duplicated char
        if (first == -1) return hasDuplicate;

        return second != -1 // second diff present
        && ss[first] == gs[second] && ss[second] == gs[first]; // diffs cross-matched
    }
}
// @lc code=end

