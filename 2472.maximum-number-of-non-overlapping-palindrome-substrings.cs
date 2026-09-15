/*
 * @lc app=leetcode id=2472 lang=csharp
 *
 * [2472] Maximum Number of Non-overlapping Palindrome Substrings
 */

// @lc code=start
public class Solution
{
    private bool IsPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] != s[right]) return false;
            left++;
            right--;
        }
        return true;
    }

    public int MaxPalindromes(string s, int k)
    {
        int n = s.Length;
        int count = 0;
        int i0 = 0;
        /*
         * Any palindrome with length more than k + 1
         * contains a palinromic substring of length k or k + 1
         */
        while (i0 <= n - k)
        {
            // Try palindrome of length k
            if (IsPalindrome(s, i0, i0 + k - 1))
            {
                count++;
                i0 += k; // because we need non-overlaping palindromes
                continue;
            }

            // length k + 1
            if (i0 + k < n && IsPalindrome(s, i0, i0 + k))
            {
                count++;
                i0 += k + 1;
                continue;
            }

            i0++;
        }

        return count;
    }
}
// @lc code=end
