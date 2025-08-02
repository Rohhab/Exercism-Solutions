static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) => DateTime.Parse(appointmentDateDescription);

    public static bool HasPassed(DateTime appointmentDate) => DateTime.Now.CompareTo(appointmentDate) > 0;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) => (appointmentDate.Hour >= 12 && appointmentDate.Hour < 18);

    public static string Description(DateTime appointmentDate) => $"You have an appointment on {appointmentDate.ToString("G")}.";

    public static DateTime AnniversaryDate() => new DateTime(2025, 9, 15, 0, 0, 0);
}
