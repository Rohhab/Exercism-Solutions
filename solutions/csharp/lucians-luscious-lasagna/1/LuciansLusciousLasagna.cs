class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven()
    {
        return 40;
    }

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int elapsedTime)
    {
        return 40 - elapsedTime;
    }
    
    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int noOfLayers)
    {
        return noOfLayers * 2;
    }
    
    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int noOfLayers, int elapsedTime)
    {
        return PreparationTimeInMinutes(noOfLayers) + elapsedTime;
    }
}
