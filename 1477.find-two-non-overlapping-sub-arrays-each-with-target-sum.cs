/*
 * @lc app=leetcode id=1477 lang=csharp
 *
 * [1477] Find Two Non-overlapping Sub-arrays Each With Target Sum
 */

// @lc code=start
public class Solution
{
    const int INF = 1_000_000; // max length is 10^5, so 10^6 is big enough

    public int MinSumOfLengths(int[] arr, int target)
    {
        int n = arr.Length;

        // minimum length of a prefix (0..i) subarray with sum equal to target
        int[] minLeftSubLen = new int[n];

        int left = 0;
        int runningSum = 0;
        int res = INF;
        int bestLenSoFar = INF;
        for (int right = 0; right < n; right++)
        {
            runningSum += arr[right];
            while (runningSum > target) runningSum -= arr[left++];

            if (runningSum == target)
            {
                int length = right - left + 1;

                if (left > 0 && minLeftSubLen[left - 1] > 0)
                    res = Math.Min(res, length + minLeftSubLen[left - 1]);

                bestLenSoFar = Math.Min(bestLenSoFar, length);
            }

            if (right > 0)
            {
                minLeftSubLen[right] = Math.Min(minLeftSubLen[right - 1], bestLenSoFar);
            }
            else
            {
                minLeftSubLen[right] = bestLenSoFar;
            }
        }

        return res < INF ? res : -1;
    }
}
// @lc code=end
