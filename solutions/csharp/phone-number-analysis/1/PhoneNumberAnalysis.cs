using System.Text.RegularExpressions;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber) => (Regex.IsMatch(phoneNumber, @"212-\d{3}-\d{4}"), Regex.IsMatch(phoneNumber, @"\d{3}-555-\d{4}"), Regex.Match(phoneNumber, @"\d{4}$").Groups[0].Value);

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}
