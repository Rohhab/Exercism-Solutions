using System.Text;

public static class RnaTranscription
{
    public static char ToComplement(char nucleotide) => nucleotide switch
    {
            'G' => 'C',
            'C' => 'G',
            'T' => 'A',
            'A' => 'U',
            _ => throw new ArgumentOutOfRangeException(nameof(nucleotide), $"Invalid nucleotide {nucleotide} provided.")
    };
    
    public static string ToRna(string strand) => new (strand.Select(ToComplement).ToArray());
    // {
        // StringBuilder sb = new StringBuilder(strand.Length);
        // foreach (char nucleotide in strand)
        // {
        //     sb.Append(ToComplement(nucleotide));
        // }
        // return sb.ToString();
    // }
}