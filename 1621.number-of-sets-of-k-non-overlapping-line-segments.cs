/*
 * @lc app=leetcode id=1621 lang=csharp
 *
 * [1621] Number of Sets of K Non-Overlapping Line Segments
 */

// @lc code=start

public class Solution
{
    private const int MOD = 1_000_000_007;

    public int NumberOfSets(int n, int k)
    {
        // We are picking 2 * k points, as a segment has two endpoints
        int choose = 2 * k;
        /*
         * Extend the space of points by k - 1 extra points,
         * as endpoints could be shared
         */
        int total = n + k - 1;

        // as C(N, M) = C(N, N - M)
        if (total - choose < choose) choose = total - choose;

        long numerator = 1;
        long denominator = 1;
        for (int i = 1; i <= choose; i++)
        {
            numerator = numerator * (total - i + 1) % MOD;
            denominator = denominator * i % MOD;
        }

        // Fermat's little theorem: a/b % MOD == a * b^(MOD-2) % MOD when MOD is prime
        long inverseDenominator = 1;
        int exp = MOD - 2;
        while (exp > 0)
        {
            if ((exp & 1) == 1) inverseDenominator = inverseDenominator * denominator % MOD;
            denominator = denominator * denominator % MOD;
            exp >>= 1;
        }

        return (int)(numerator * inverseDenominator % MOD);
    }
}
// @lc code=end
