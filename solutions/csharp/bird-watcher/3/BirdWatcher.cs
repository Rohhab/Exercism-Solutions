class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today() => birdsPerDay[birdsPerDay.Length - 1];

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        var comparator = 0;
        
        foreach(var i in birdsPerDay)
        {
            if(i == 0)
            {
                comparator++;                
            }
        }

        if(comparator > 0)
        {
            return true;            
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        var sum = 0;
        
        for(var i = 0; i < numberOfDays; i++)
        {
            sum += birdsPerDay[i];
        }

        return sum;
    }

    public int BusyDays()
    {
        var busyDays = 0;

        foreach(var i in birdsPerDay)
        {
            if(i >= 5)
                busyDays++;
        }
        
        return busyDays;
    }
}
