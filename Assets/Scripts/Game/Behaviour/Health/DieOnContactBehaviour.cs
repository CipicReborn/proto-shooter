


namespace Game.Behaviour.Health
{
    public class DieOnContactBehaviour : Behaviour<DamagersCollided, HealthAfterDamage>
    {
        public DieOnContactBehaviour(IInput<DamagersCollided> input, IHealthSystemController controller) : base(input, controller)
        {
            this.controller = controller;
        }

        private static HealthAfterDamage living = new HealthAfterDamage(0, 1);
        private static HealthAfterDamage dead = new HealthAfterDamage(0, 0);

        private IHealthSystemController HealthController;

        override protected HealthAfterDamage GetResult(DamagersCollided damagers)
        {
            if (damagers.List.Count > 0)
            {
                (controller as IHealthSystemController).Destroy();
                return dead;
            }
            return living;
        }
    }
}