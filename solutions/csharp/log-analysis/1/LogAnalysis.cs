using System.Text.RegularExpressions;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimiter) => Regex.Match(str, @$"{Regex.Escape(delimiter)}(.+)", RegexOptions.Singleline).Groups[1].Value;
    // {
        // int startIndex = str.IndexOf(delimiter) + delimiter.Length;
        // return str.Substring(startIndex, str.Length - startIndex);
    // }

    public static string SubstringBetween(this string str, string startingDelimiter, string endingDelimiter) => Regex.Match(str, @$"{Regex.Escape(startingDelimiter)}(.+){Regex.Escape(endingDelimiter)}").Groups[1].Value;
    // {        
        // int indexOfStartingDelimiter = str.IndexOf(startingDelimiter) + startingDelimiter.Length;
        // int length = str.IndexOf(endingDelimiter) - indexOfStartingDelimiter;
        // return str.Substring(indexOfStartingDelimiter, length);
    // }
    
    public static string Message(this string str) => str.SubstringAfter(": ");

    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}