/*
 * @lc app=leetcode id=3619 lang=csharp
 *
 * [3619] Count Islands With Total Value Divisible by K
 */

// @lc code=start
public class Solution
{
    public int CountIslands(int[][] grid, int k)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                // Found an unvisited land cell (positive value)
                if (grid[r][c] > 0)
                {
                    long totalValue = Dfs(grid, r, c, rows, cols);

                    if (totalValue % k == 0)
                        count++;
                }

        return count;
    }
    private static long Dfs(int[][] grid, int r, int c, int rows, int cols)
    {
        // Out of bounds or water cell (0)
        if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] == 0)
            return 0;

        // Retrieve current cell value and sink it (mark as visited)
        long currentVal = grid[r][c];
        grid[r][c] = 0;

        // Recursively sum values across all 4 directions
        long sum = currentVal;
        sum += Dfs(grid, r + 1, c, rows, cols);
        sum += Dfs(grid, r - 1, c, rows, cols);
        sum += Dfs(grid, r, c + 1, rows, cols);
        sum += Dfs(grid, r, c - 1, rows, cols);

        return sum;
    }

}
// @lc code=end

