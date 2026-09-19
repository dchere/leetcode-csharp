/*
 * @lc app=leetcode id=1401 lang=csharp
 *
 * [1401] Circle and Rectangle Overlapping
 */

// @lc code=start
public class Solution
{
    public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2)
    {
        int dxRight = xCenter - x2;
        if (dxRight > radius) return false;
        int dyTop = yCenter - y2;
        if (dyTop > radius) return false;
        int dxLeft = xCenter - x1;
        if (dxLeft < -radius) return false;
        int dyBottom = yCenter - y1;
        if (dyBottom < -radius) return false;
        int R2 = radius * radius;
        if (dxLeft < 0)
            if (dyTop > 0)
                return dxLeft * dxLeft + dyTop * dyTop <= R2;
            else if (dyBottom < 0)
                return dxLeft * dxLeft + dyBottom * dyBottom <= R2;
            else
                return true;
        else if (dxRight > 0)
            if (dyTop > 0)
                return dxRight * dxRight + dyTop * dyTop <= R2;
            else if (dyBottom < 0)
                return dxRight * dxRight + dyBottom * dyBottom <= R2;
            else
                return true;
        return true;
    }
}
// @lc code=end

