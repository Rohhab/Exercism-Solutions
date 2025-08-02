using System.Collections.Generic;

public class Robot
{
    private static HashSet<string> assignedNames = new();
    private static HashSet<string> usedNames = new();
    private static Random rand = new();
    
    public string Name { get; private set; }

    public Robot() => nameGenerator(2, 3);

    public void nameGenerator(int letterCount, int digitCount)
    {
        string candidate;
        do
        {
            string letters = new string(Enumerable.Range(0, letterCount)
                    .Select(_ => (char)rand.Next('A', 'Z' + 1))
                    .ToArray());
            string digits = new string(Enumerable.Range(0, digitCount)
                    .Select(_ => (char)rand.Next('0', '9' + 1))
                    .ToArray());
            candidate = letters + digits;
        } while(assignedNames.Contains(candidate) || usedNames.Contains(candidate));
        assignedNames.Add(candidate);
        Name = candidate;
    }

    public void Reset()
    {
        assignedNames.Remove(Name);
        usedNames.Add(Name);
        nameGenerator(2, 3);
    }
}