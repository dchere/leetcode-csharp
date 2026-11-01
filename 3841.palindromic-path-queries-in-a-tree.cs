/*
 * @lc app=leetcode id=3841 lang=csharp
 *
 * [3841] Palindromic Path Queries in a Tree
 */

// @lc code=start
using System;
using System.Collections.Generic;
using System.Numerics;

public class Solution
{
    private int timer = 0;
    private int LOGN;
    private int[][] up;
    private int[] depth;

    public IList<bool> PalindromePath(int n, int[][] edges, string s, string[] queries)
    {
        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; i++) adj[i] = new List<int>();

        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        LOGN = 1;
        while ((1 << LOGN) <= n) LOGN++;

        up = new int[n][];
        for (int i = 0; i < n; i++) up[i] = new int[LOGN];

        depth = new int[n];
        int[] tin = new int[n];
        int[] tout = new int[n];
        int[] initialPrefMask = new int[n];

        // 1. DFS for Euler Tour and Binary Lifting LCA initialization
        Dfs(0, 0, 0, s, adj, tin, tout, initialPrefMask);

        // 2. Initialize Fenwick Tree
        FenwickTree bit = new FenwickTree(n);
        for (int i = 0; i < n; i++)
        {
            bit.UpdateRange(tin[i], tin[i], initialPrefMask[i]);
        }

        char[] currentChars = s.ToCharArray();

        List<bool> result = new List<bool>();

        // 3. Process Queries
        foreach (var q in queries)
        {
            ReadOnlySpan<char> span = q.AsSpan();

            if (span[0] == 'u')
            {
                // Parse update
                int firstSpace = span.IndexOf(' ');
                int secondSpace = span.Slice(firstSpace + 1).IndexOf(' ') + firstSpace + 1;

                int u = int.Parse(span.Slice(firstSpace + 1, secondSpace - firstSpace - 1));
                char newChar = span[secondSpace + 1];
                char oldChar = currentChars[u];

                if (oldChar != newChar)
                {
                    int diffMask = (1 << (oldChar - 'a')) ^ (1 << (newChar - 'a'));
                    bit.UpdateRange(tin[u], tout[u], diffMask);
                    currentChars[u] = newChar;
                }
            }
            else // "query"
            {
                int firstSpace = span.IndexOf(' ');
                int secondSpace = span.Slice(firstSpace + 1).IndexOf(' ') + firstSpace + 1;

                int u = int.Parse(span.Slice(firstSpace + 1, secondSpace - firstSpace - 1));
                int v = int.Parse(span.Slice(secondSpace + 1));

                int lca = GetLca(u, v);

                int maskU = bit.Query(tin[u]);
                int maskV = bit.Query(tin[v]);
                int lcaNodeMask = 1 << (currentChars[lca] - 'a');

                // Correct formula: maskU ^ maskV ^ lcaNodeMask
                int pathMask = maskU ^ maskV ^ lcaNodeMask;

                result.Add(BitOperations.PopCount((uint)pathMask) <= 1);
            }
        }

        return result;
    }

    private void Dfs(int u, int p, int currentMask, string s, List<int>[] adj, int[] tin, int[] tout, int[] prefMask)
    {
        tin[u] = ++timer;
        up[u][0] = p;

        for (int i = 1; i < LOGN; i++)
        {
            up[u][i] = up[up[u][i - 1]][i - 1];
        }

        currentMask ^= (1 << (s[u] - 'a'));
        prefMask[u] = currentMask;

        foreach (int v in adj[u])
        {
            if (v != p)
            {
                depth[v] = depth[u] + 1;
                Dfs(v, u, currentMask, s, adj, tin, tout, prefMask);
            }
        }

        tout[u] = timer;
    }

    private int GetLca(int u, int v)
    {
        if (depth[u] < depth[v]) (u, v) = (v, u);

        for (int i = LOGN - 1; i >= 0; i--)
        {
            if (depth[u] - (1 << i) >= depth[v])
            {
                u = up[u][i];
            }
        }

        if (u == v) return u;

        for (int i = LOGN - 1; i >= 0; i--)
        {
            if (up[u][i] != up[v][i])
            {
                u = up[u][i];
                v = up[v][i];
            }
        }

        return up[u][0];
    }

    private class FenwickTree
    {
        private readonly int[] tree;
        private readonly int size;

        public FenwickTree(int n)
        {
            size = n + 2;
            tree = new int[size];
        }

        public void UpdateRange(int l, int r, int val)
        {
            PointUpdate(l, val);
            PointUpdate(r + 1, val);
        }

        private void PointUpdate(int idx, int val)
        {
            for (; idx < size; idx += idx & -idx)
            {
                tree[idx] ^= val;
            }
        }

        public int Query(int idx)
        {
            int xorSum = 0;
            for (; idx > 0; idx -= idx & -idx)
            {
                xorSum ^= tree[idx];
            }
            return xorSum;
        }
    }
}
// @lc code=end

