public interface IRemoteControlCar
{
    int NumberOfVictories { get; set; }
    int DistanceTravelled { get; set; }
    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<IRemoteControlCar>
{
    public int DistanceTravelled { get; set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(IRemoteControlCar other)
    {
        if (NumberOfVictories < other.NumberOfVictories)
        {
            return -1;
        }
        else if (NumberOfVictories == other.NumberOfVictories)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var rankings = new List<ProductionRemoteControlCar>();
        if(prc1.CompareTo(prc2) == -1)
        {
            rankings.Add(prc1);
            rankings.Add(prc2);
        }
        else if(prc1.CompareTo(prc2) == 1)
        {
            rankings.Add(prc2);
            rankings.Add(prc1);
        }
        return rankings;
    }
}
