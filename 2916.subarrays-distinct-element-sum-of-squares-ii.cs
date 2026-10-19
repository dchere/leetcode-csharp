/*
 * @lc app=leetcode id=2916 lang=csharp
 *
 * [2916] Subarrays Distinct Element Sum of Squares II
 */

// @lc code=start

public class Solution
{
    private const int MOD = 1_000_000_007;

    public int SumCounts(int[] nums)
    {
        int n = nums.Length;
        SegmentTree tree = new SegmentTree(n);

        Dictionary<int, int> lastPos = new Dictionary<int, int>();

        long totalAns = 0;

        for (int j = 0; j < n; j++)
        {
            int val = nums[j];
            int prevIdx = lastPos.GetValueOrDefault(val, -1);

            tree.Update(1, 0, n - 1, prevIdx + 1, j, 1);

            totalAns = (totalAns + tree.QueryTotalSq()) % MOD;

            lastPos[val] = j;
        }

        return (int)totalAns;
    }

    private class SegmentTree
    {
        private readonly int n;
        private readonly long[] sumC;
        private readonly long[] sumSq;
        private readonly long[] lazy;

        public SegmentTree(int size)
        {
            n = size;
            int treeSize = 4 * n;
            sumC = new long[treeSize];
            sumSq = new long[treeSize];
            lazy = new long[treeSize];
        }

        public long QueryTotalSq() => sumSq[1];

        public void Update(int node, int start, int end, int l, int r, long val)
        {
            Push(node, start, end);

            if (l > end || r < start) return;

            if (l <= start && end <= r)
            {
                lazy[node] += val;
                Push(node, start, end);
                return;
            }

            int mid = start + (end - start) / 2;
            int leftChild = node * 2;
            int rightChild = node * 2 + 1;

            Update(leftChild, start, mid, l, r, val);
            Update(rightChild, mid + 1, end, l, r, val);

            sumC[node] = (sumC[leftChild] + sumC[rightChild]) % MOD;
            sumSq[node] = (sumSq[leftChild] + sumSq[rightChild]) % MOD;
        }

        private void Push(int node, int start, int end)
        {
            if (lazy[node] == 0) return;

            long add = lazy[node];
            long len = end - start + 1;

            // Формула: (c + add)^2 = c^2 + 2 * add * c + add^2 * len
            long addSq = add * add % MOD;

            sumSq[node] = (sumSq[node] + 2 * add % MOD * sumC[node] % MOD + addSq * len % MOD) % MOD;
            sumC[node] = (sumC[node] + add * len % MOD) % MOD;

            if (start != end)
            {
                lazy[node * 2] += add;
                lazy[node * 2 + 1] += add;
            }

            lazy[node] = 0;
        }
    }
}
// @lc code=end

