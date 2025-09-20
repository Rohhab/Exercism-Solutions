public class TeamStat
{
    public int MP, W, D, L, P;
}

public static class Tournament
{
    public static Dictionary<string, TeamStat> teams = new();

    public static void updateStats(string input, Dictionary<string, TeamStat> team)
    {
        string[] line = input.Split(';');
        string teamA = line[0];
        string teamB = line[1];
        string matchResult = line[2];

        if(!team.ContainsKey(teamA))
            team.Add(teamA, new TeamStat());
        if(!team.ContainsKey(teamB))
            team.Add(teamB, new TeamStat());
        
        switch(matchResult)
        {
            case "win":
                team[teamA].MP++;
                team[teamB].MP++;
                team[teamA].W++;
                team[teamB].L++;
                team[teamA].P += 3;
                break;

            case "draw":
                team[teamA].MP++;
                team[teamB].MP++;
                team[teamA].D++;
                team[teamB].D++;
                team[teamA].P++;
                team[teamB].P++;
                break;

            case "loss":
                team[teamA].MP++;
                team[teamB].MP++;
                team[teamA].L++;
                team[teamB].W++;
                team[teamB].P += 3;
                break;
        }
    }

    public static string formatter(string input, TeamStat stats)
    {
        return $"{input.PadRight(31)}| {stats.MP,2} | {stats.W,2} | {stats.D,2} | {stats.L,2} | {stats.P,2}";
    }
    
    public static void Tally(Stream inStream, Stream outStream)
    {
        StreamReader reader = new StreamReader(inStream);
        StreamWriter writer = new StreamWriter(outStream);
        teams.Clear();
        
        string line;
        string header = "Team                           | MP |  W |  D |  L |  P";
        
        while((line = reader.ReadLine()) != null)
        {
            updateStats(line, teams);
        }
        
        if(teams.Count == 0)
        {
            writer.Write(header);            
        }
        else
        {
            writer.WriteLine(header);            
        }

        var orderedTeams = teams
            .OrderByDescending(e => e.Value.P)
            .ThenBy(e => e.Key)
            .ToList();

        for(int i = 0; i < orderedTeams.Count; i++)
        {
            if(i == orderedTeams.Count - 1)
            {
                writer.Write(formatter(orderedTeams[i].Key, orderedTeams[i].Value));                
            }
            else
            {
                writer.WriteLine(formatter(orderedTeams[i].Key, orderedTeams[i].Value));                
            }
        }
        
        writer.Flush();
    }
}
