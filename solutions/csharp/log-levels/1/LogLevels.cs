static class LogLine
{
    public static string Message(string logLine)
    {
        var index = logLine.IndexOf(":") + 1;
        var untrimmedMessage = logLine.Substring(index);
        var message = untrimmedMessage.Trim();
        return message;
    }

    public static string LogLevel(string logLine)
    {
        var firstIndex = logLine.IndexOf("[") + 1;
        var lastIndex = logLine.IndexOf("]") - 1;
        var untrimmedMessage = logLine.Substring(firstIndex, lastIndex);
        var level = untrimmedMessage.ToLower();
        return level;
    }

    public static string Reformat(string logLine)
    {
        var message = Message(logLine);
        var level = LogLevel(logLine);
        return $"{message} ({level})";
    }
}
