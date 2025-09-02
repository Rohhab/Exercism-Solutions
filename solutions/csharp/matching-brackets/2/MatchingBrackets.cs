public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        Stack<char> judge = new();
        var pairs = new Dictionary<char, char> {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (char c in input)
        {
            if (pairs.ContainsValue(c))
            {
                judge.Push(c);
            }
            else if (pairs.TryGetValue(c, out char expectedOpen))
            {
                if (judge.Count == 0 || judge.Pop() != expectedOpen)
                {
                    return false;
                }
            }
        }

        return judge.Count == 0;
    }
}
