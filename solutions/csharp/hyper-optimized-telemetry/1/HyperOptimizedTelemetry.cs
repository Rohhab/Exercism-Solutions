public static class TelemetryBuffer
{    
    public static byte[] ToBuffer(long reading)
    {
        // Determine the payload size
        
        var prefixByte = 0;
        var payloadSize = 0;

        if (reading >= -9223372036854775808 && reading <= -2147483649)
        {
            //long
            payloadSize = 8;
            prefixByte = 248;
        }
        else if (reading >= -2147483648 && reading <= -32769)
        {
            //int
            payloadSize = 4;
            prefixByte = 252;
        }
        else if (reading >= -32768 && reading <= -1)
        {
            // short
            payloadSize = 2;
            prefixByte = 254;
        }
        else if (reading >= 0 && reading <= 65535)
        {
            // ushort
            payloadSize = 2;
            prefixByte = 2;
        }
        else if (reading >= 65536 && reading <= 2147483647)
        {
            // int
            payloadSize = 4;
            prefixByte = 252;
        }
        else if (reading >= 2147483648 && reading <= 4294967295)
        {
            // uint
            payloadSize = 4;
            prefixByte = 4;
        }
        else if (reading >= 4294967296 && reading <= 9223372036854775807)
        {
            // long
            payloadSize = 8;
            prefixByte = 248;
        }

        byte[] buffer = new byte[9];
        buffer[0] = (byte)prefixByte;
        byte[] payload = BitConverter.GetBytes(reading);

        Array.Copy(payload, 0, buffer, 1, payloadSize);

        return buffer;
    }


    public static long FromBuffer(byte[] buffer)
    {
        byte prefixByte = buffer[0];

        return prefixByte switch
        {
            248 => BitConverter.ToInt64(buffer, 1),
            252 => BitConverter.ToInt32(buffer, 1),
            254 => BitConverter.ToInt16(buffer, 1),
            2 => BitConverter.ToUInt16(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            _ => 0
        };
    }
}
