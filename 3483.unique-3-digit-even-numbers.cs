/*
 * @lc app=leetcode id=3483 lang=csharp
 *
 * [3483] Unique 3-Digit Even Numbers
 */

// @lc code=start
public class Solution
{
    public int TotalNumbers(int[] digits)
    {
        int res = 0;
        HashSet<int> hundreds = [];
        HashSet<int> units = [];
        int[] count = new int[10];
        foreach (int d in digits)
        {
            if (d % 2 == 0) units.Add(d);
            if (d != 0) hundreds.Add(d);
            count[d]++;
        }
        if (units.Count == 0 || hundreds.Count == 0) return 0;
        foreach (int a in hundreds)
        {
            count[a]--;
            for (int b = 0; b < 10; b++)
            {
                if (count[b] == 0) continue;
                count[b]--;
                foreach (int c in units)
                {
                    if (count[c] > 0) res++;
                }
                count[b]++;
            }
            count[a]++;
        }
        return res;
    }
}
// @lc code=end

