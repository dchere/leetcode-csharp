/*
 * @lc app=leetcode id=2089 lang=csharp
 *
 * [2089] Find Target Indices After Sorting Array
 */

// @lc code=start
public class Solution
{
    public IList<int> TargetIndices(int[] nums, int target)
    {
        int nTargets = 0;
        int iFirstTarget = 0;
        foreach (int num in nums)
            if (num < target)
                iFirstTarget++;
            else if (num == target)
                nTargets++;
        if (nTargets == 0) return [];
        int[] res = new int[nTargets];
        for (int i = 0; i < nTargets; i++)
            res[i] = iFirstTarget + i;
        return res;
    }
}
// @lc code=end

