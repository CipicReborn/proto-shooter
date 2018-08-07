using Sirenix.OdinInspector;
using Game.Behaviour;
using Game.Behaviour.Health;

namespace UnityShooter
{
    public class AudioHealthFeedbackController : SerializedMonoBehaviour, IFeedbackEffect<HealthAfterDamage>
    {
        public IDamageFeedback DamageSFX;
        public IDestructionFeedback DestructionSFX;

        public void Tick(HealthAfterDamage damageResult)
        {
            if (damageResult.remainingHealth > 0)
            {
                //DamageSFX.Trigger(damageResult.damageTaken);
            }
            else
            {
                DestructionSFX.Trigger();
            }
        }
    }
}