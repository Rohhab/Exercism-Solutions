public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {       
        List<uint> result = new();
        
        foreach(uint original in numbers)
        {
            List<byte> temp = new();
            uint num = original;
            
            do
            {
                var chunk = (byte)(num & 0x7F);
                num >>= 7;
                temp.Add(chunk);
            }
            while(num > 0);
            
            temp.Reverse();
            
            for(int i = 0; i < temp.Count - 1; i++)
                temp[i] |= 0x80;
            
            result.AddRange(temp.Select(b => (uint)b));
        }
        return result.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        List<uint> result = new();
        uint val = 0;
        bool expectingMore = false;
        
        foreach(uint original in bytes)
        {
            uint num = original;
            val = (val << 7) | (num & 0x7F);
            expectingMore = (num & 0x80) != 0;
            if(!expectingMore)
            {
                result.Add(val);
                val = 0;
            }
        }

        if(expectingMore)
            throw new InvalidOperationException("Incomplete VLQ sequence.");
        
        return result.ToArray();
    }
}