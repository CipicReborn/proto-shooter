namespace Game.Behaviour.Health
{
    public interface IHealthData
    {
        int MaxHealthPoints { get; }
        float DelayBeforeDestruction { get; }
    }
}
