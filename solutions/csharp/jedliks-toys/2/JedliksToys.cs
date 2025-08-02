class RemoteControlCar
{
    private int _meteresDriven = 0;
    private int _batteryPercentage = 100;
    
    public static RemoteControlCar Buy() =>
        new RemoteControlCar
        {
        _meteresDriven = 0,
        _batteryPercentage = 100,
        };

    public string DistanceDisplay() => $"Driven {_meteresDriven} meters";

    public string BatteryDisplay() => (_batteryPercentage == 0) ? "Battery empty" : $"Battery at {_batteryPercentage}%";

    public void Drive()
    {
        if(_batteryPercentage == 0)
        {
            BatteryDisplay();
        }
        else
        {
        _meteresDriven += 20;
        _batteryPercentage -= 1;            
        }
    }
}
