using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {        
        if(string.IsNullOrEmpty(identifier))
        {
            return "";
        }

        var cleanIdentifier = new StringBuilder();
        var nextUpper = false;

        foreach(var c in identifier)
        {
            if(c == ' ')
            {
                cleanIdentifier.Append('_');
            }
            else if(char.IsControl(c))
            {
                cleanIdentifier.Append("CTRL");
            }
            else if(c == '-')
            {
                nextUpper = true;
            }
            else if(char.IsLetter(c) && (c < 'α' || c > 'ω'))
            {
                cleanIdentifier.Append(nextUpper ? char.ToUpper(c) : c);
                nextUpper = false;
            }
        }

        identifier = cleanIdentifier.ToString();
        return identifier;
    }
}
