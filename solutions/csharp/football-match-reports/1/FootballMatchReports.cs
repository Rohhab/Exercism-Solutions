public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
                break;

            case 2:
                return "left back";
                break;

            case 3:
            case 4:
                return "center back";
                break;

            case 5:
                return "right back";
                break;

            case 6:
            case 7:
            case 8:
                return "midfielder";
                break;

            case 9:
                return "left wing";
                break;

            case 10:
                return "striker";
                break;

            case 11:
                return "right wing";
                break;

            default:
                return "UNKNOWN";
                break;
        }
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
                return "The referee deemed a foul.";
                break;

            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
                // var constructor = injury.GetType().GetConstructors().FirstOrDefault();
                // var args = constructor?.GetParameters();
    
                // if (args?.Length > 0)
                // {
                //     var field = injury.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).FirstOrDefault(f => f.FieldType == args[0].ParameterType);
        
                //     var playerNumber = field?.GetValue(injury);
                //     return $"Oh no! Player {playerNumber} is injured. Medics are on the field.";
                // }
                // else
                // {
                //     return "UNIDI";
                // }
                break;
                
            case Incident incident:
                return "An incident happened.";
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
