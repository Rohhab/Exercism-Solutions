using System.Runtime.InteropServices;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    private static string LocationOSSpecifier(Location location) => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
            location switch
            {
                    Location.NewYork => "Eastern Standard Time",
                    Location.London => "GMT Standard Time",
                    Location.Paris => "W. Europe Standard Time",
            } :
            location switch
            {
                    Location.NewYork => "America/New_York",
                    Location.London => "Europe/London",
                    Location.Paris => "Europe/Paris",
            };
        
    public static DateTime Schedule(string appointmentDateDescription, Location location) => TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), TimeZoneInfo.FindSystemTimeZoneById(LocationOSSpecifier(location)));

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        TimeSpan offset = alertLevel switch
        {
            AlertLevel.Early => TimeSpan.FromDays(1),
            AlertLevel.Standard => TimeSpan.FromMinutes(105),
            AlertLevel.Late => TimeSpan.FromMinutes(30)
        };

        return appointment - offset;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(LocationOSSpecifier(location));
        var dST = timeZone.IsDaylightSavingTime(dt);
        var pST = timeZone.IsDaylightSavingTime(dt.AddDays(-7));

        return dST != pST;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var culture = location switch
        {
                Location.NewYork => "en-US",
                Location.London => "en-GB",
                Location.Paris => "fr-FR"
        };

        return DateTime.TryParse(dtStr, new CultureInfo(culture), out var result) ? result : DateTime.MinValue;
    }
}
