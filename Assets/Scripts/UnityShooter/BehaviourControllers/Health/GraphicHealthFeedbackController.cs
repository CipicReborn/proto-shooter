using Sirenix.OdinInspector;
using Game.Behaviour;
using Game.Behaviour.Health;
using UnityEngine;

namespace UnityShooter
{
    public class GraphicHealthFeedbackController : SerializedMonoBehaviour, IFeedbackEffect<HealthAfterDamage>
    {
        public IDamageFeedback DamageFeedback;
        public IDestructionFeedback DestructionFeedback;

        public void Tick(HealthAfterDamage damageResult)
        {
            if (damageResult.remainingHealth > 0)
            {
                DamageFeedback.Trigger(damageResult.damageTaken);
            }
            else
            {
                DestructionFeedback.Trigger();
            }
        }
    }
}