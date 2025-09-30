public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        Dictionary<char, int> charCount = new();
        
        foreach(char original in word)
        {
            char c = char.ToLower(original);
            if(c == '-' | c == ' ')
                continue;
            if(!charCount.ContainsKey(c))
            {
                charCount.Add(c, 1);
            }
            else
            {
                charCount[c]++;
                if(charCount[c] > 1)
                    return false;
            }
        }
        return true;
    }
}
