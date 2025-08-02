class WeighingMachine
{
    public int Precision { get; private set; }
    private double weight;
    
    public double Weight
    {
        get => weight;
        set
        {
            if (value >= 0)
                weight = value;
            else
                throw new ArgumentOutOfRangeException("Weight cannot be negative.");
        }
    }

    public double TareAdjustment { get; set; } = 5;
    
    public string DisplayWeight
    {
        get => $"{(weight - TareAdjustment).ToString($"f{Precision}")} kg";
    }

    public WeighingMachine(int precision)
    {
        this.Precision = precision;
    }
}
