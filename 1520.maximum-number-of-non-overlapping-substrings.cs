/*
 * @lc app=leetcode id=1520 lang=csharp
 *
 * [1520] Maximum Number of Non-Overlapping Substrings
 */

// @lc code=start
public class Solution
{
    public IList<string> MaxNumOfSubstrings(string s)
    {
        int n = s.Length;

        // first and last occurrence of each char
        int[] first = new int[26];
        int[] last = new int[26];
        Array.Fill(first, -1);
        Array.Fill(last, -1);
        for (int i = 0; i < n; i++)
        {
            int ch = s[i] - 'a';
            if (first[ch] == -1) first[ch] = i;
            last[ch] = i;
        }

        List<(int left, int right)> validIntervals = new List<(int, int)>();
        // For each char its first[ch] could be a valid start of a substring
        for (int i = 0; i < 26; i++)
        {
            if (first[i] == -1) continue;

            int start = first[i];
            int end = GetValidEnd(s, start, first, last);

            // if a valid end index exists
            if (end != -1) validIntervals.Add((start, end));
        }

        // sort intervals by right end for a greedy algorithm
        validIntervals.Sort((a, b) => a.right.CompareTo(b.right));

        // and pick non-overlapping intervals
        List<string> result = [];
        int lastEnd = -1;

        foreach (var (l, r) in validIntervals)
        {
            if (l > lastEnd)
            {
                result.Add(s.Substring(l, r - l + 1));
                lastEnd = r;
            }
        }

        return result;
    }

    private int GetValidEnd(string s, int start, int[] first, int[] last)
    {
        int end = last[s[start] - 'a'];
        int j = start;

        while (j <= end)
        {
            int ch = s[j] - 'a';

            // letter appears before start — interval is not valid
            if (first[ch] < start) return -1;

            end = Math.Max(end, last[ch]);
            j++;
        }

        return end;
    }
}
// @lc code=end

