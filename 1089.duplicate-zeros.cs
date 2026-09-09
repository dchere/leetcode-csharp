/*
 * @lc app=leetcode id=1089 lang=csharp
 *
 * [1089] Duplicate Zeros
 */

// @lc code=start

public class Solution
{
    public void DuplicateZeros(int[] arr)
    {
        int i1 = arr.Length;
        int nZeros = 0;
        int i = 0;
        while (i + nZeros < i1)
        {
            if (arr[i] == 0)
            {
                if (i + nZeros == i1 - 1)
                {
                    arr[i1 - 1] = 0;
                    i1--; // Reduce array boundary so we don't write it again
                    break;
                }
                nZeros++;
            }
            i++;
        }

        if (nZeros == 0) return; // nothing to modify

        int cur = i - 1;
        while (cur >= 0)
        {
            if (arr[cur] == 0) arr[cur + nZeros--] = 0;
            arr[cur + nZeros] = arr[cur];
            cur--;
        }
    }
}

// @lc code=end

