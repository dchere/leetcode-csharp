/*
 * @lc app=leetcode id=3568 lang=csharp
 *
 * [3568] Minimum Moves to Clean the Classroom
 */

// @lc code=start

public class Solution
{
    public int MinMoves(string[] classroom, int energy)
    {
        int m = classroom.Length;
        int n = classroom[0].Length;

        // litterIndex[r, c] is meaningful only when classroom[r][c] == 'L'
        int[,] litterIndex = new int[m, n];
        int nLitters = 0;
        int r0 = -1;
        int c0 = -1;
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                char cell = classroom[r][c];
                if (cell == 'S')
                {
                    r0 = r;
                    c0 = c;
                }
                else if (cell == 'L')
                {
                    litterIndex[r, c] = nLitters++;
                }
            }
        }

        if (nLitters == 0) return 0;

        // A bitmask is enough; there are at most 10 litter cells.
        int targetMask = (1 << nLitters) - 1;

        // Store energy + 1 so 0 means unvisited (no need to fill with -1).
        int[,,] bestEnergy = new int[m, n, 1 << nLitters];

        Queue<(int r, int c, int mask, int e)> queue = new();
        queue.Enqueue((r0, c0, 0, energy));
        bestEnergy[r0, c0, 0] = energy + 1;

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };
        int moves = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int q = 0; q < size; q++)
            {
                var (r, c, mask, e) = queue.Dequeue();

                if (mask == targetMask) return moves; // all litter collected
                if (e == 0) continue; // no energy left to move

                for (int d = 0; d < 4; d++)
                {
                    int nr = r + dr[d];
                    if (nr < 0 || nr >= m) continue;
                    int nc = c + dc[d];
                    if (nc < 0 || nc >= n) continue;

                    char cell = classroom[nr][nc];
                    if (cell == 'X') continue;

                    int nextEnergy = cell == 'R' ? energy : e - 1;
                    int nextMask = mask;
                    if (cell == 'L') nextMask |= 1 << litterIndex[nr, nc];

                    if (nextEnergy == 0 && nextMask != targetMask) continue;

                    // Already reached this cell and mask with at least this much energy
                    if (nextEnergy + 1 <= bestEnergy[nr, nc, nextMask]) continue;

                    bestEnergy[nr, nc, nextMask] = nextEnergy + 1;
                    queue.Enqueue((nr, nc, nextMask, nextEnergy));
                }
            }
            moves++;
        }

        return -1;
    }
}
// @lc code=end
