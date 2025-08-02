class Lasagna
{
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int elapsedTime) => ExpectedMinutesInOven() - elapsedTime;
    
    public int PreparationTimeInMinutes(int noOfLayers) => noOfLayers * 2;
    
    public int ElapsedTimeInMinutes(int noOfLayers, int elapsedTime) => PreparationTimeInMinutes(noOfLayers) + elapsedTime;
}
