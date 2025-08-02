static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        department ??= "OWNER";
        return id.HasValue ? $"[{id}] - {name} - {department.ToUpper()}" : $"{name} - {department.ToUpper()}";
        
        // if (department == null)
        // {
        //     if (id == null)
        //     {
        //         return $"{name} - OWNER";
        //     }
        //     return $"[{id}] - {name} - OWNER";
        // }
        // else if (id == null)
        // {
        //     return $"{name} - {department?.ToUpper()}";
        // }
        // else
        // {
        //     return $"[{id}] - {name} - {department?.ToUpper()}";
        // }
    }
}
