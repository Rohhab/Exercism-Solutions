public static class MatchingBrackets
{   
    public static bool IsPaired(string input)
    {
        Stack<char> judge = new();
        var pairs = new Dictionary<char, char> {
            {')', '('},
            {']', '['},
            {'}', '{'}
        };
        
        foreach(char c in input)
        {
            if(pairs.ContainsValue(c))
            {
                judge.Push(c);
                continue;
            }
            else if(pairs.ContainsKey(c))
            {
                if(judge.Count == 0)
                {
                    return false;
                    break;
                }
                
                char top = judge.Peek();
                if(top != pairs[c])
                {
                    return false;
                    break;
                }
                else
                {
                    judge.Pop();
                }
            }
        }
        
        return judge.Count == 0;
    }
}