/*
 * @lc app=leetcode id=3863 lang=csharp
 *
 * [3863] Minimum Operations to Sort a String
 */

// @lc code=start
public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;
        if (n == 1)
            return 0;
        if (n == 2)
            return s[0] <= s[1] ? 0 : -1;

        char min = s[0];
        char max = s[0];
        bool isSorted = true;

        for (int i = 1; i < n; i++)
        {
            if (s[i] < s[i - 1]) isSorted = false;
            if (s[i] < min) min = s[i];
            if (s[i] > max) max = s[i];
        }

        if (isSorted)
            return 0;

        if (s[0] == max && s[n - 1] == min)
        {
            for (int i = 1; i < n - 1; i++)
                if (s[i] == min || s[i] == max)
                    return 2;

            return 3;
        }

        if (s[0] == min || s[n - 1] == max)
            return 1;

        return 2;
    }
}
// @lc code=end

