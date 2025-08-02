public static class TwoFer
{
    // public static string Speak() => "One for you, one for me.";
    // public static string Speak(string name) => $"One for {name}, one for me.";

    public static string Speak(string name = null)
    {
        string actualName = string.IsNullOrWhiteSpace(name) ? "you" : name;
        return $"One for {actualName}, one for me.";
    }
}
