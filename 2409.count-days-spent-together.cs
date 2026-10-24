/*
 * @lc app=leetcode id=2409 lang=csharp
 *
 * [2409] Count Days Spent Together
 */

// @lc code=start
public class Solution
{
    private static readonly int[] daysBeforeTheMonth = [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334];
    private int DayOfYeare(string date)
    {
        int month = (date[0] - '0') * 10 + date[1] - '0';
        int day = (date[3] - '0') * 10 + date[4] - '0';
        return daysBeforeTheMonth[month - 1] + day;
    }
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        int aliceDay0 = DayOfYeare(arriveAlice);
        int aliceDay1 = DayOfYeare(leaveAlice);
        int bobDay0 = DayOfYeare(arriveBob);
        if (bobDay0 > aliceDay1)
            return 0;
        int bobDay1 = DayOfYeare(leaveBob);
        if (bobDay1 < aliceDay0)
            return 0;
        return 1
        + ((aliceDay1 < bobDay1) ? aliceDay1 : bobDay1)
        - ((aliceDay0 > bobDay0) ? aliceDay0 : bobDay0);
    }
}
// @lc code=end

