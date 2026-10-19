/*
 * @lc app=leetcode id=2897 lang=csharp
 *
 * [2897] Apply Operations on Array to Maximize Sum of Squares
 */

// @lc code=start
public class Solution
{
    private const int MOD = 1_000_000_007;
    public int MaxSum(IList<int> nums, int k)
    {
        Span<int> bitCount = stackalloc int[30];
        int n = nums.Count;

        for (int i = 0; i < n; i++)
        {
            int val = nums[i];
            for (int b = 0; b < 30; b++)
            {
                if ((val & (1 << b)) != 0)
                    bitCount[b]++;
            }
        }

        long totalSum = 0;

        // 2. Жадібно формуємо k найбільших чисел
        for (int step = 0; step < k; step++)
        {
            long currentNum = 0;

            for (int b = 0; b < 30; b++)
            {
                if (bitCount[b] > 0)
                {
                    currentNum |= 1L << b;
                    bitCount[b]--;
                }
            }

            long square = (currentNum % MOD) * (currentNum % MOD) % MOD;
            totalSum = (totalSum + square) % MOD;
        }

        return (int)totalSum;
    }
}
// @lc code=end

