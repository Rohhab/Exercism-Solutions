class RemoteControlCar
{
    private int speed;
    private int distance = 0;
    private int batteryDrain;
    private int batteryCap = 100;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => batteryCap < 0 || batteryCap < batteryDrain;

    public int DistanceDriven()
    {
        return distance;
    }

    public void Drive()
    {
        if(BatteryDrained())
        {
            distance += 0;
        }
        else
        {
            distance += speed;
            batteryCap -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int distance;
    private int carDistance;
    
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while(!car.BatteryDrained())
        {
            car.Drive();
            carDistance = car.DistanceDriven();
        }

        if(carDistance >= this.distance)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
}
