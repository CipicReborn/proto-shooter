using UnityEngine;

namespace UnityShooter
{
    public interface IActorAbility
    {
        GameObject gameObject { get; }

        void Init();
        void Tick();
    }
}
