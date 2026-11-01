/*
 * @lc app=leetcode id=3882 lang=csharp
 *
 * [3882] Minimum XOR Path in a Grid
 */

// @lc code=start
public class Solution
{
    public int MinCost(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // dp[c, val] indicates whether XOR value 'val' can be achieved at column 'c' in the current row
        bool[,] dp = new bool[n, 1024];

        // Base case: starting point (0, 0)
        dp[0, grid[0][0]] = true;

        // Initialize first row (can only move Right)
        for (int c = 1; c < n; c++)
        {
            int val = grid[0][c];
            for (int x = 0; x < 1024; x++)
                if (dp[c - 1, x])
                    dp[c, x ^ val] = true;
        }

        // Process remaining rows
        for (int r = 1; r < m; r++)
        {
            bool[,] nextDp = new bool[n, 1024];

            for (int c = 0; c < n; c++)
            {
                int val = grid[r][c];

                for (int x = 0; x < 1024; x++)
                {
                    // Transition from cell directly above (r - 1, c)
                    if (dp[c, x])
                        nextDp[c, x ^ val] = true;

                    // Transition from cell directly to the left (r, c - 1)
                    if (c > 0 && nextDp[c - 1, x])
                        nextDp[c, x ^ val] = true;
                }
            }

            dp = nextDp;
        }

        // Find the minimum achievable XOR value at destination (m - 1, n - 1)
        for (int v = 0; v < 1024; v++)
            if (dp[n - 1, v])
                return v;

        return 0;
    }
}
// @lc code=end

