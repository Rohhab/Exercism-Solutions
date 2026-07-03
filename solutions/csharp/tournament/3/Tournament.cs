public class TeamStat
{
    public int MP, W, D, L, P;
}

public static class Tournament
{
    public static Dictionary<string, TeamStat> teams = new();

    public static TeamStat GetOrCreate(Dictionary<string, TeamStat> team, string name) => team.TryGetValue(name, out var stat) ? stat : team[name] = new TeamStat();

    public static void updateStats(string input, Dictionary<string, TeamStat> team)
    {
        string[] line = input.Split(';');
        TeamStat teamA = GetOrCreate(team, line[0]);
        TeamStat teamB = GetOrCreate(team, line[1]);
        string matchResult = line[2];

        teamA.MP++;
        teamB.MP++;
        switch(matchResult)
        {
            case "win":
                teamA.W++; teamB.L++; teamA.P += 3;
                break;
            
            case "draw":
                teamA.D++; teamB.D++; teamA.P++; teamB.P++;
                break;

            case "loss":
                teamA.L++; teamB.W++; teamB.P += 3;
                break;
        }
    }

    public static string formatter(string input, TeamStat stats)
    {
        return $"{input.PadRight(31)}| {stats.MP,2} | {stats.W,2} | {stats.D,2} | {stats.L,2} | {stats.P,2}";
    }
    
    public static void Tally(Stream inStream, Stream outStream)
    {
        teams.Clear();
        string header = "Team                           | MP |  W |  D |  L |  P";
        
        using StreamReader reader = new StreamReader(inStream);
        using StreamWriter writer = new StreamWriter(outStream);
        
        string line;
        while((line = reader.ReadLine()) != null)
            updateStats(line, teams);
        
        if(teams.Count == 0)
        {
            writer.Write(header);            
        }
        else
        {
            writer.WriteLine(header);            
        }

        var lines = teams
            .OrderByDescending(e => e.Value.P)
            .ThenBy(e => e.Key)
            .Select(e => formatter(e.Key, e.Value));

        writer.Write(string.Join('\n', lines));
    }
}
