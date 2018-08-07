

public static class GameServices
{
    public static BoundariesCalculator Boundaries { get { return boundaries; } }
    private static BoundariesCalculator boundaries = new BoundariesCalculator();

    public static LevelTicker LevelTicker { get; set; }
}
