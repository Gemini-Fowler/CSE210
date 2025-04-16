public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int durationInMinutes, double distanceKm)
        : base(date, durationInMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance() => _distanceKm;
    public override double GetSpeed() => (_distanceKm / Duration) * 60;
    public override double GetPace() => Duration / _distanceKm;
}
