static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        var time = DateTime.Parse(appointmentDateDescription);

        return time;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        var output = DateTime.Now.CompareTo(appointmentDate);
        return (output > 0);
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return (appointmentDate.Hour >= 12 && appointmentDate.Hour <18);
    }

    public static string Description(DateTime appointmentDate)
    {
        var description = appointmentDate.ToString("G");
        return $"You have an appointment on {description}.";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(2025, 9, 15, 0, 0, 0);
    }
}
