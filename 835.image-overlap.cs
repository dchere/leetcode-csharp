/*
 * @lc app=leetcode id=835 lang=csharp
 *
 * [835] Image Overlap
 */

// @lc code=start
public class Solution
{
    public int LargestOverlap(int[][] img1, int[][] img2)
    {
        int n = img1.Length;
        // shift on n is not large enough to prevent colliding of (dr, dc) vectors
        int shift = 2 * n - 1;
        int maxOnes = n * n;
        int[] ones1 = new int[maxOnes];
        int count1 = 0;
        int[] ones2 = new int[maxOnes];
        int count2 = 0;
        // Pack the row and column of each 1 as row * shift + column
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (img1[r][c] == 1) ones1[count1++] = r * shift + c;
                if (img2[r][c] == 1) ones2[count2++] = r * shift + c;
            }
        }

        if (count1 == 0 || count2 == 0) return 0;

        /*
         * Counts of packed shift vectors.
         * Originally: from -(n - 1) * shift - (n - 1) to (n - 1) * shift + (n - 1)
         * Offset shifts them to keep all indices non-negative
         */
        int offset = (shift + 1) * (n - 1);
        int[] vectorCounts = new int[2 * offset + 1];
        int maxOverlap = 0;
        for (int i = 0; i < count1; i++)
        {
            int p1 = ones1[i];
            for (int j = 0; j < count2; j++)
            {
                // The difference of two packed coordinates is the packed shift vector
                int packedVector = p1 - ones2[j] + offset;

                vectorCounts[packedVector]++;
                if (vectorCounts[packedVector] > maxOverlap)
                {
                    maxOverlap = vectorCounts[packedVector];
                }
            }
        }

        return maxOverlap;
    }
}
// @lc code=end

