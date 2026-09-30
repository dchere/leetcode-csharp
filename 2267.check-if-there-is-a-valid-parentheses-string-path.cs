/*
 * @lc app=leetcode id=2267 lang=csharp
 *
 * [2267]  Check if There Is a Valid Parentheses String Path
 */

// @lc code=start
public class Solution
{
    private int m;
    private int n;
    private char[][] grid;
    private bool[,,] visited;

    public bool HasValidPath(char[][] grid)
    {
        m = grid.Length;
        n = grid[0].Length;
        this.grid = grid;

        int totalLen = m + n - 1;
        if (totalLen % 2 != 0)
            return false;
        if (grid[0][0] == ')' || grid[m - 1][n - 1] == '(')
            return false;

        int maxBal = totalLen / 2;
        visited = new bool[m, n, maxBal + 1];

        return Dfs(0, 0, 0);
    }
    private bool Dfs(int r, int c, int bal)
    {
        bal += (grid[r][c] == '(') ? 1 : -1;

        if (bal < 0 || bal > (m + n - 1) / 2)
            return false;

        if (r == m - 1 && c == n - 1)
            return bal == 0;

        if (visited[r, c, bal])
            return false;
        visited[r, c, bal] = true;

        if (r + 1 < m && Dfs(r + 1, c, bal))
            return true;
        if (c + 1 < n && Dfs(r, c + 1, bal))
            return true;

        return false;
    }
}
// @lc code=end

