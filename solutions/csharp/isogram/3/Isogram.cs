public static class Isogram
{
    public static bool IsIsogram(string word) => word
        .ToLower()
        .Where(c => c != '-' && c != ' ')
        .GroupBy(c => c)
        .All(g => g.Count() == 1);
}
