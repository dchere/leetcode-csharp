/*
 * @lc app=leetcode id=3665 lang=csharp
 *
 * [3665] Twisted Mirror Path Count
 */

// @lc code=start
using System;

public class Solution
{
    private const int MOD = 1_000_000_007;

    public int UniquePaths(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // Allocate DP state directly on the thread stack (0 Heap Allocations)
        Span<int> dpDown = stackalloc int[n];
        Span<int> dpRight = stackalloc int[n];

        // Base case initialization at (0, 0)
        dpDown[0] = 1;
        dpRight[0] = 0;

        // Process Row 0 (can only move Right)
        int[] row0 = grid[0];
        for (int j = 1; j < n; j++)
        {
            // Moving Right from (0, j - 1)
            dpRight[j] = row0[j - 1] == 0
                ? (dpDown[j - 1] + dpRight[j - 1] >= MOD ? dpDown[j - 1] + dpRight[j - 1] - MOD : dpDown[j - 1] + dpRight[j - 1])
                : dpDown[j - 1];
            dpDown[j] = 0;
        }

        // Process Rows 1 to m - 1
        for (int i = 1; i < m; i++)
        {
            int[] prevRow = grid[i - 1];
            int[] currRow = grid[i];

            // Column 0 (can only move Down)
            int prevDown0 = dpDown[0];
            int prevRight0 = dpRight[0];
            dpDown[0] = prevRow[0] == 0
                ? (prevDown0 + prevRight0 >= MOD ? prevDown0 + prevRight0 - MOD : prevDown0 + prevRight0)
                : prevRight0;
            dpRight[0] = 0;

            // Columns 1 to n - 1 (Hot Inner Loop)
            for (int j = 1; j < n; j++)
            {
                int pDown = dpDown[j];
                int pRight = dpRight[j];

                // Transition from ABOVE (i - 1, j) -> entering (i, j) moving DOWN
                int nextDown = prevRow[j] == 0
                    ? (pDown + pRight >= MOD ? pDown + pRight - MOD : pDown + pRight)
                    : pRight;

                // Transition from LEFT (i, j - 1) -> entering (i, j) moving RIGHT
                int leftDown = dpDown[j - 1];
                int leftRight = dpRight[j - 1];
                int nextRight = currRow[j - 1] == 0
                    ? (leftDown + leftRight >= MOD ? leftDown + leftRight - MOD : leftDown + leftRight)
                    : leftDown;

                dpDown[j] = nextDown;
                dpRight[j] = nextRight;
            }
        }

        int total = dpDown[n - 1] + dpRight[n - 1];
        return total >= MOD ? total - MOD : total;
    }
}
// @lc code=end

