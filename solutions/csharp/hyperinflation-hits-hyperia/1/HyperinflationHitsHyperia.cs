public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            checked
            {
                return $"{@base * multiplier}";
            }
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        return Single.IsInfinity(@base * multiplier) ? "*** Too Big ***" : $"{@base * multiplier}";
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            checked
            {
                return $"{salaryBase * multiplier}";
            }
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
