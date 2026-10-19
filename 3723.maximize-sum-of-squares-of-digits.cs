/*
 * @lc app=leetcode id=3723 lang=csharp
 *
 * [3723] Maximize Sum of Squares of Digits
 */

// @lc code=start
public class Solution
{
    public string MaxSumOfSquares(int num, int sum)
    {
        if (sum > num * 9)
            return "";

        return string.Create(num, sum, (span, currentSum) =>
        {
            for (int i = 0; i < span.Length; i++)
            {
                if (currentSum > 0)
                {
                    int digit = Math.Min(9, currentSum);
                    span[i] = (char)('0' + digit);
                    currentSum -= digit;
                }
                else
                {
                    span[i] = '0';
                }
            }
        });

    }
}
// @lc code=end

