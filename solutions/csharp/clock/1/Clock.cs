public class Clock
{
    private int _hours = 0;
    private int _minutes = 0;
    
    public Clock(int hours, int minutes)
    {        
        int totalMinutes = hours * 60 + minutes;
        totalMinutes = ((totalMinutes % 1440) + 1440) % 1440;
        _hours = totalMinutes / 60;
        _minutes = totalMinutes % 60;
    }

    public Clock Add(int minutesToAdd) => new Clock(_hours, _minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(_hours, _minutes - minutesToSubtract);

    public override string ToString() => $"{_hours:D2}:{_minutes:D2}";

    public override bool Equals(Object obj)
    {
        if(obj is Clock other)
        {
            return _hours == other._hours && _minutes == other._minutes;
        }
        return false;
    }
}
