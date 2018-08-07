namespace Game.Behaviour.Health
{
    public struct HealthAfterDamage
    {
        public HealthAfterDamage (int damageTaken, int remainingHP)
        {
            this.damageTaken = damageTaken;
            remainingHealth = remainingHP;
        }

        public int damageTaken;
        public int remainingHealth;

        public override string ToString()
        {
            return "HealthAfterDamage { DamageTaken : " + damageTaken + ", Remaining HP : " + remainingHealth + "}";
        }
    }
}
