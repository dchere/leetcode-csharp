/*
 * @lc app=leetcode id=1254 lang=csharp
 *
 * [1254] Number of Closed Islands
 */

// @lc code=start
public class Solution
{
    public int ClosedIsland(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        // Step 1: Flood fill all islands connected to the boundary
        for (int r = 0; r < rows; r++)
        {
            if (grid[r][0] == 0) Dfs(grid, r, 0, rows, cols);
            if (grid[r][cols - 1] == 0) Dfs(grid, r, cols - 1, rows, cols);
        }

        for (int c = 0; c < cols; c++)
        {
            if (grid[0][c] == 0) Dfs(grid, 0, c, rows, cols);
            if (grid[rows - 1][c] == 0) Dfs(grid, rows - 1, c, rows, cols);
        }

        // Step 2: Count remaining isolated (closed) islands
        int closedIslands = 0;
        for (int r = 1; r < rows - 1; r++)
        {
            for (int c = 1; c < cols - 1; c++)
            {
                if (grid[r][c] == 0)
                {
                    closedIslands++;
                    Dfs(grid, r, c, rows, cols); // Sink the counted island
                }
            }
        }

        return closedIslands;
    }

    private static void Dfs(int[][] grid, int r, int c, int rows, int cols)
    {
        // Boundary check and water check
        if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] == 1)
            return;

        // Mark current cell as visited/water
        grid[r][c] = 1;

        // Explore all 4 orthogonal directions
        Dfs(grid, r + 1, c, rows, cols);
        Dfs(grid, r - 1, c, rows, cols);
        Dfs(grid, r, c + 1, rows, cols);
        Dfs(grid, r, c - 1, rows, cols);
    }
}
// @lc code=end

