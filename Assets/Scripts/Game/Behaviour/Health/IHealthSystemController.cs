

namespace Game.Behaviour.Health
{
    public interface IHealthSystemController : IAudioGraphicBehaviourController<HealthAfterDamage>
    {
        void Destroy ();
    }
}