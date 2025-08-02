using System.Text.RegularExpressions;

public class LogParser
{    
    public bool IsValidLine(string text) => Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");

    public string[] SplitLogLine(string text) => Regex.Split(text, @"<[\^\*\=\-]+>");

    public int CountQuotedPasswords(string lines) => Regex.Matches(lines, @"""[^""]*password[^""]*""", RegexOptions.IgnoreCase).Count;

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\d+", string.Empty);

    public string[] ListLinesWithPasswords(string[] lines)
    {        
        List<string> outputList = new List<string>();
        
        foreach(string line in lines)
        {
            var match = Regex.Match(line, @"\bpassword\w+", RegexOptions.IgnoreCase);
            var prefix = match.Success ? match.Groups[0].Value : "--------";
            outputList.Add($"{prefix}: {line}");
        }

        return outputList.ToArray();
    }
}
