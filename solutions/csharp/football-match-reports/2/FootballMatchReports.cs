public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch
        {
                1 => "goalie",
                2=> "left back",
                3 or 4 => "center back",
                5 => "right back",
                6 or 7 or 8 => "midfielder",
                9 => "left wing",
                10 => "striker",
                11 => "right wing",
                _ => "UNKNOWN"
        };
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int supporters:
                return $"There are {report} supporters at the match.";
                break;

            case string message:
                return message;
                break;

            case Foul foul:
                return foul.GetDescription();
                break;

            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
                break;
                
            case Incident incident:
                return incident.GetDescription();
                break;

            case Manager manager when manager.Club == null:
                return $"{manager.Name}";
                break;

            case Manager manager:
                return $"{manager.Name} ({manager.Club})";
                break;

            default:
                return "";
        }
    }
}
