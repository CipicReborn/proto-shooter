

namespace Game.Behaviour.Health
{
    /// <summary>
    /// Never gets out of life, informs of received damage
    /// </summary>
    public class UndamageableBehaviour : AudioGraphicBehaviour<DamagersCollided, HealthAfterDamage>
    {

        private static HealthAfterDamage noDamage = new HealthAfterDamage(0, 1);
        private static HealthAfterDamage ignoredDamage = new HealthAfterDamage(1, 1);

        public UndamageableBehaviour(IInput<DamagersCollided> input, IAudioGraphicBehaviourController<HealthAfterDamage> controller) :
            base(input, controller)
        {
        }

        override protected HealthAfterDamage GetResult(DamagersCollided damagers)
        {
            for (int i = 0; i < damagers.List.Count; i++)
            {
                if (damagers.List[i].GetDamage() > 0)
                {
                    return ignoredDamage;
                }
            }
            return noDamage;
        }
    }

}