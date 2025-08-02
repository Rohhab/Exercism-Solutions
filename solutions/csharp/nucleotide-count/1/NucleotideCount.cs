using System.Linq;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        foreach(char c in sequence)
        {
            if(c != 'A' && c != 'C' && c != 'G' && c != 'T')
                throw new ArgumentException("Shit happens!");
        }
        
        int countOfA = sequence.Count(c => c == 'A');
        int countOfC = sequence.Count(c => c == 'C');
        int countOfG = sequence.Count(c => c == 'G');
        int countOfT = sequence.Count(c => c == 'T');

        var outputDict = new Dictionary<char, int>();
        outputDict.Add('A', countOfA);
        outputDict.Add('C', countOfC);
        outputDict.Add('G', countOfG);
        outputDict.Add('T', countOfT);

        return outputDict;
    }
}