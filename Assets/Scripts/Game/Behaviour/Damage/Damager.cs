namespace Game.Behaviour.Damage
{
    public class Damager
    {
        public Damager(IDamageData data, IBehaviourController controller)
        {
            this.data = data;
            this.controller = controller;
        }
        public int GetDamage()
        {
            return data.Damage;
        }

#if UNITY_EDITOR
        public string GetName()
        {
            return controller.ObjectName;
        }
#endif

        private IDamageData data;
        private IBehaviourController controller;

        public override string ToString()
        {
            return controller.ObjectName + " - " + data.Damage + " damage";
        }

    }
}
