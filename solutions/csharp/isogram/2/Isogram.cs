public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        HashSet<char> seen = new();
        
        foreach(char original in word)
        {
            char c = char.ToLower(original);
            if(c == '-' | c == ' ')
                continue;
            if(!seen.Add(c))
                return false;
        }
        return true;
    }
}
