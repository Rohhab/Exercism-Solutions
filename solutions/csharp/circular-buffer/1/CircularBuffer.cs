public class CircularBuffer<T>
{
    private readonly T[] buffer;
    private int WriteIndex;
    private int ReadIndex;
    public int Count { get; private set; }
    
    public CircularBuffer(int capacity)
    {
        buffer = new T[capacity];
        WriteIndex = 0;
        ReadIndex = 0;
        Count = 0;
    }

    public T Read()
    {
        if(Count == 0)
            throw new InvalidOperationException("The Buffer is Empty.");
        
        int CurrentReadIndex = ReadIndex;
        T item = buffer[CurrentReadIndex];
        buffer[CurrentReadIndex] = default(T);
        ReadIndex = (ReadIndex + 1) % buffer.Length;
        Count--;

        return item;
    }

    public void Write(T value)
    {
        if(Count < buffer.Length)
        {
            buffer[WriteIndex] = value;
            WriteIndex = (WriteIndex + 1) % buffer.Length;
            Count++;            
        }
        else
        {
            throw new InvalidOperationException("Full buffer cannot be written to.");
        }
    }

    public void Overwrite(T value)
    {
        if(Count < buffer.Length)
        {
            buffer[WriteIndex] = value;
            WriteIndex = (WriteIndex + 1) % buffer.Length;
            Count++;
        }
        else
        {
            buffer[WriteIndex] = value;
            WriteIndex = (WriteIndex + 1) % buffer.Length;
            ReadIndex = (ReadIndex + 1) % buffer.Length;
        }
    }

    public void Clear()
    {
        for(int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = default(T);
        }
        WriteIndex = 0;
        ReadIndex = 0;
        Count = 0;
    }
}