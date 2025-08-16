using System.Text.RegularExpressions;

public static class Bob
{    
    public static string Response(string statement)
    {
        string letters = Regex.Replace(statement, @"[^A-Za-z]", "");
        string trimmed = statement.Trim();
        bool isQuestion = trimmed.EndsWith("?");
        bool isYelling = letters.Length > 0 && letters.ToUpper() == letters;

        if(isYelling && isQuestion)
            return "Calm down, I know what I'm doing!";
        
        if(isYelling)
            return "Whoa, chill out!";
        
        if(isQuestion)
            return "Sure.";
        
        if(string.IsNullOrWhiteSpace(statement))
            return "Fine. Be that way!";
        
        return "Whatever.";
    }
}