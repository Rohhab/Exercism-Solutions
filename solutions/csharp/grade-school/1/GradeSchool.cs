using System.Collections.Generic;

public class GradeSchool
{
    private Dictionary<string, int> roster = [];
    
    public bool Add(string student, int grade) => roster.TryAdd(student, grade);

    public IEnumerable<string> Roster() => roster
                                            .OrderBy(pair => pair.Value)
                                            .ThenBy(pair => pair.Key)
                                            .Select(pair => pair.Key);

    public IEnumerable<string> Grade(int grade) => roster
                                                    .Where(pair => pair.Value == grade)
                                                    .OrderBy(pair => pair.Key)
                                                    .Select(pair => pair.Key);
}