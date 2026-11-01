/*
 * @lc app=leetcode id=3970 lang=csharp
 *
 * [3970] Shortest Path With At Most K Consecutive Identical Characters
 */

// @lc code=start

public class Solution
{
    public int ShortestPath(int n, int[][] edges, string labels, int k)
    {
        // 1. Build Adjacency List: adj[u] -> list of (v, weight)
        List<(int v, int w)>[] adj = new List<(int, int)>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<(int, int)>();
        }

        foreach (var edge in edges)
        {
            adj[edge[0]].Add((edge[1], edge[2]));
        }

        // 2. Initialize Distance Table: dist[u, count]
        // count ranges from 1 to k (since node 0 starts with count = 1)
        int[,] dist = new int[n, k + 1];
        for (int i = 0; i < n; i++)
        {
            for (int c = 1; c <= k; c++)
            {
                dist[i, c] = int.MaxValue;
            }
        }

        // Min-PriorityQueue storing state (node, consecutiveCount) prioritized by distance
        var pq = new PriorityQueue<(int node, int count), int>();

        // Starting state: node 0 with 1 consecutive character (its own label)
        dist[0, 1] = 0;
        pq.Enqueue((0, 1), 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out var state, out int d);
            int u = state.node;
            int count = state.count;

            // Early exit if destination node is reached
            if (u == n - 1)
                return d;

            // Skip stale priority queue entries
            if (d > dist[u, count])
                continue;

            char charU = labels[u];

            foreach (var (v, w) in adj[u])
            {
                char charV = labels[v];
                int nextCount = (charU == charV) ? count + 1 : 1;

                // Enforce at most k consecutive identical characters
                if (nextCount <= k)
                {
                    int nextDist = d + w;

                    if (nextDist < dist[v, nextCount])
                    {
                        dist[v, nextCount] = nextDist;
                        pq.Enqueue((v, nextCount), nextDist);
                    }
                }
            }
        }

        return -1;
    }
}
// @lc code=end

