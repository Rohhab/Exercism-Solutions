public static class Pangram
{    
    public static bool IsPangram(string input)
    {
        var letters = input
            .Where(char.IsLetter)
            .Select(char.ToLower)
            .Distinct()
            .OrderBy(c => c)
            .Count();
            
        return letters == 26;
    }
}
