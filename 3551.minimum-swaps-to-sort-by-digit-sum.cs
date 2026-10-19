/*
 * @lc app=leetcode id=3551 lang=csharp
 *
 * [3551] Minimum Swaps to Sort by Digit Sum
 */

// @lc code=start
public class Solution
{
    public int MinSwaps(int[] nums)
    {
        int n = nums.Length;

        Element[] elements = new Element[n];
        for (int i = 0; i < n; i++)
            elements[i] = new Element(nums[i], GetDigitSum(nums[i]), i);

        Array.Sort(elements, (a, b) =>
        {
            if (a.DigitSum != b.DigitSum)
                return a.DigitSum.CompareTo(b.DigitSum);
            return a.Value.CompareTo(b.Value);
        });

        bool[] visited = new bool[n];
        int swaps = 0;

        for (int i = 0; i < n; i++)
        {
            if (visited[i] || elements[i].OriginalIndex == i)
                continue;

            int cycleSize = 0;
            int curr = i;

            while (!visited[curr])
            {
                visited[curr] = true;
                curr = elements[curr].OriginalIndex;
                cycleSize++;
            }

            if (cycleSize > 1)
                swaps += cycleSize - 1;
        }

        return swaps;
    }

    private static int GetDigitSum(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }

    private readonly struct Element
    {
        public readonly int Value;
        public readonly int DigitSum;
        public readonly int OriginalIndex;

        public Element(int value, int digitSum, int originalIndex)
        {
            Value = value;
            DigitSum = digitSum;
            OriginalIndex = originalIndex;
        }
    }
}
// @lc code=end

