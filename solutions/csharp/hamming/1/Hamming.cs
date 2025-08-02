public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int diffCount = 0;
        
        if(firstStrand is null || secondStrand is null)
            throw new ArgumentNullException("Input strands cannot be null.");
        
        if(firstStrand.Length != secondStrand.Length)
            throw new ArgumentException("Strands must be of equal length.");
        
        for(int i = 0; i < firstStrand.Length; i++)
        {
            if(firstStrand[i] != secondStrand[i])
                diffCount++;
        }
        return diffCount;
    }
}