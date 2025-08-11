using System.Text;

public static class RotationalCipher
{    
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder sb = new StringBuilder();
        int offset = shiftKey % 26;

        foreach(char character in text)
        {
            char baseCharacter = char.IsUpper(character) ? 'A' : 'a';
            if(char.IsLetter(character))
            {
                char shifted = (char)(baseCharacter + (character - baseCharacter + offset) % 26);
                sb.Append(shifted);
            }
            else
            {
                sb.Append(character);
            }
        }
        
        return sb.ToString();
    }
}