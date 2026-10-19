/*
 * @lc app=leetcode id=2778 lang=csharp
 *
 * [2778] Sum of Squares of Special Elements 
 */

// @lc code=start

public class Solution
{
    public int SumOfSquares(int[] nums)
    {
        int n = nums.Length;
        int sum = 0;
        int sqrt = (int)Math.Sqrt(n);

        for (int i = 1; i <= sqrt; i++)
        {
            if (n % i == 0)
            {
                sum += nums[i - 1] * nums[i - 1];

                int j = n / i;
                if (j != i)
                {
                    sum += nums[j - 1] * nums[j - 1];
                }
            }
        }
        return sum;
    }
}
// @lc code=end

