/*
 * @lc app=leetcode id=1096 lang=csharp
 *
 * [1096] Brace Expansion II
 */

// @lc code=start
public class Solution
{
    public IList<string> BraceExpansionII(string expression)
    {
        Stack<SortedSet<string>> operands = new();
        Stack<char> operators = new();

        int n = expression.Length;
        for (int i = 0; i < n; i++)
        {
            char c = expression[i];

            // Insert implicit multiplication * if needed
            if (i > 0)
            {
                char prev = expression[i - 1];
                if ((char.IsLower(prev) || prev == '}') && (char.IsLower(c) || c == '{'))
                {
                    // Evaluate higher precedence * operators already at the top of stack
                    while (operators.Count > 0 && operators.Peek() == '*')
                        EvaluateTop(operands, operators);
                    operators.Push('*');
                }
            }

            if (char.IsLower(c))
            {
                operands.Push(new SortedSet<string>(StringComparer.Ordinal) { c.ToString() });
            }
            else if (c == '{')
            {
                operators.Push('{');
            }
            else if (c == ',')
            {
                // ',' has lower precedence than '*'. Evaluate any preceding '*'
                while (operators.Count > 0 && operators.Peek() == '*')
                    EvaluateTop(operands, operators);
                operators.Push('+');
            }
            else if (c == '}')
            {
                // Pop and evaluate until matching '{'
                while (operators.Count > 0 && operators.Peek() != '{')
                {
                    EvaluateTop(operands, operators);
                }
                operators.Pop(); // Pop '{'
            }
        }

        // Clear remaining operators in the stack
        while (operators.Count > 0)

            EvaluateTop(operands, operators);

        return [.. operands.Pop()];
    }

    private void EvaluateTop(Stack<SortedSet<string>> operands, Stack<char> operators)
    {
        char op = operators.Pop();
        SortedSet<string> right = operands.Pop();
        SortedSet<string> left = operands.Pop();

        SortedSet<string> result = new SortedSet<string>(StringComparer.Ordinal);

        if (op == '+')
        {
            // Union: left U right
            result.UnionWith(left);
            result.UnionWith(right);
        }
        else if (op == '*')
        {
            // Cartesian Product: left x right
            foreach (string l in left)
                foreach (string r in right)
                    result.Add(l + r);
        }

        operands.Push(result);
    }
}
// @lc code=end

