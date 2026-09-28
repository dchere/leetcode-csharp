/*
 * @lc app=leetcode id=1807 lang=csharp
 *
 * [1807] Evaluate the Bracket Pairs of a String
 */

// @lc code=start
public class Solution
{
    public string Evaluate(string s, IList<IList<string>> knowledge)
    {
        // 1. Build Dictionary for O(1) key lookups
        var dict = new Dictionary<string, string>(knowledge.Count);
        foreach (var pair in knowledge)
            dict[pair[0]] = pair[1];

        // Pre-allocate capacity for the output string
        var res = new StringBuilder(s.Length);
        ReadOnlySpan<char> span = s.AsSpan();
        int keyStart = -1;

        // 2. Single-pass linear scan using index slicing
        for (int i = 0; i < span.Length; i++)
        {
            char c = span[i];

            if (c == '(')
            {
                keyStart = i + 1;
            }
            else if (c == ')')
            {
                // Extract key directly without maintaining a key buffer
                string key = span.Slice(keyStart, i - keyStart).ToString();

                if (dict.TryGetValue(key, out string value))
                    res.Append(value);
                else
                    res.Append('?');
                keyStart = -1;
            }
            else if (keyStart == -1)
            {
                // Letter outside parentheses
                res.Append(c);
            }
        }

        return res.ToString();
    }
}
// @lc code=end

