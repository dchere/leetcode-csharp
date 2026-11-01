/*
 * @lc app=leetcode id=3963 lang=csharp
 *
 * [3963] Create Grid With Exactly One Path
 */

// @lc code=start
public class Solution
{
    public string[] CreateGrid(int m, int n)
    {
        char[][] grid = new char[m][];
        for (int r = 0; r < m; r++)
        {
            grid[r] = new char[n];
            Array.Fill(grid[r], '#');
        }

        int currR = 0;
        int currC = 0;
        grid[0][0] = '.';

        // Alternate moving Right and Down to form the exact staircase path
        while (currR < m - 1 || currC < n - 1)
        {
            // Move Right if possible and not at the rightmost column
            if (currC < n - 1 && (currR == m - 1 || currC <= currR))
            {
                currC++;
            }
            // Otherwise move Down
            else if (currR < m - 1)
            {
                currR++;
            }

            grid[currR][currC] = '.';
        }

        string[] result = new string[m];
        for (int r = 0; r < m; r++)
        {
            result[r] = new string(grid[r]);
        }

        return result;
    }
}
// @lc code=end

