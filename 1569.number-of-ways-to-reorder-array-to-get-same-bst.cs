/*
 * @lc app=leetcode id=1569 lang=csharp
 *
 * [1569] Number of Ways to Reorder Array to Get Same BST
 */

// @lc code=start
public class Solution
{
    private const int MOD = 1_000_000_007;
    private int[][] table;
    public int NumOfWays(int[] nums)
    {
        int n = nums.Length;
        BuildPascalTable(n);

        List<int> list = [.. nums];
        // minus 1, to not account initial array
        return (int)((Solve(list) - 1 + MOD) % MOD);
    }
    private long Solve(List<int> list)
    {
        if (list.Count <= 2) return 1;

        int root = list[0];
        List<int> left = new List<int>();
        List<int> right = new List<int>();

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] < root)
                left.Add(list[i]);
            else
                right.Add(list[i]);
        }

        long leftWays = Solve(left);
        long rightWays = Solve(right);

        long combination = table[left.Count + right.Count][left.Count];

        // Ways = C(L + R, L) * Ways(left) * Ways(right) % MOD
        long totalWays = combination * leftWays % MOD;
        totalWays = totalWays * rightWays % MOD;

        return totalWays;
    }
    private void BuildPascalTable(int n)
    {
        table = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            table[i] = new int[i + 1];
            table[i][0] = 1;
            table[i][i] = 1;
            for (int j = 1; j < i; j++)
                table[i][j] = (table[i - 1][j - 1] + table[i - 1][j]) % MOD;
        }
    }
}
// @lc code=end

