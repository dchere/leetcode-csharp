/*
 * @lc app=leetcode id=836 lang=csharp
 *
 * [836] Rectangle Overlap
 */

// @lc code=start
public class Solution
{
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        if (rec1[0] >= rec2[2] || rec2[0] >= rec1[2]) return false;
        if (rec1[1] >= rec2[3] || rec2[1] >= rec1[3]) return false;
        return true;
    }
}
// @lc code=end

