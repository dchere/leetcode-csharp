/*
 * @lc app=leetcode id=3525 lang=csharp
 *
 * [3525] Find X Value of Array II
 */

// @lc code=start
public class Solution
{
    private struct Node
    {
        public int Prod;
        public unsafe fixed int Cnt[5];
    }

    private class SegmentTree
    {
        private readonly int n;
        private readonly int k;
        private readonly Node[] tree;

        public SegmentTree(int[] nums, int k)
        {
            n = nums.Length;
            this.k = k;
            tree = new Node[4 * n];
            Build(nums, 1, 0, n - 1);
        }

        private void Build(int[] nums, int node, int start, int end)
        {
            if (start == end)
            {
                int val = nums[start] % k;
                tree[node].Prod = val;
                unsafe { tree[node].Cnt[val] = 1; }
                return;
            }

            int mid = start + (end - start) / 2;
            int left = 2 * node, right = 2 * node + 1;

            Build(nums, left, start, mid);
            Build(nums, right, mid + 1, end);

            tree[node] = Merge(tree[left], tree[right]);
        }

        public void Update(int idx, int val)
        {
            Update(1, 0, n - 1, idx, val % k);
        }

        private void Update(int node, int start, int end, int idx, int val)
        {
            if (start == end)
            {
                tree[node].Prod = val;
                unsafe
                {
                    for (int r = 0; r < k; r++) tree[node].Cnt[r] = 0;
                    tree[node].Cnt[val] = 1;
                }
                return;
            }

            int mid = start + (end - start) / 2;
            int left = 2 * node, right = 2 * node + 1;

            if (idx <= mid) Update(left, start, mid, idx, val);
            else Update(right, mid + 1, end, idx, val);

            tree[node] = Merge(tree[left], tree[right]);
        }

        private Node Merge(in Node left, in Node right)
        {
            Node res = default;
            res.Prod = left.Prod * right.Prod % k;

            unsafe
            {
                for (int r = 0; r < k; r++) res.Cnt[r] = left.Cnt[r];

                int leftProd = left.Prod;
                for (int r = 0; r < k; r++)
                    if (right.Cnt[r] > 0)
                        res.Cnt[leftProd * r % k] += right.Cnt[r];
            }

            return res;
        }

        public int Query(int startQuery, int targetX)
        {
            Node res = Query(1, 0, n - 1, startQuery, n - 1);
            unsafe { return res.Cnt[targetX]; }
        }

        private Node Query(int node, int start, int end, int l, int r)
        {
            if (l <= start && end <= r) return tree[node];

            int mid = start + (end - start) / 2;
            int left = 2 * node, right = 2 * node + 1;

            if (r <= mid) return Query(left, start, mid, l, r);
            if (l > mid) return Query(right, mid + 1, end, l, r);

            return Merge(Query(left, start, mid, l, r), Query(right, mid + 1, end, l, r));
        }
    }

    public int[] ResultArray(int[] nums, int k, int[][] queries)
    {
        int qLen = queries.Length;
        int[] result = new int[qLen];

        SegmentTree segTree = new SegmentTree(nums, k);

        for (int i = 0; i < qLen; i++)
        {
            segTree.Update(queries[i][0], queries[i][1]);
            result[i] = segTree.Query(queries[i][2], queries[i][3]);
        }

        return result;
    }
}
// @lc code=end

