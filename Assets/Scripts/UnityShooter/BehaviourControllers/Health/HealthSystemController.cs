using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Health;

namespace UnityShooter
{
    public class HealthSystemController : AudioGraphicBehaviourController<HealthAfterDamage>, IHealthSystemController
    {
        public override string ObjectName { get { return transform.parent.name + " - HealthSystemController"; } }
        
        [Header("Settings")]
        public IInput<DamagersCollided> input;
        [SerializeField]
        private IHealthData HealthData;
        [SerializeField]
        private GameObject TheOneWhoDies;

        private HealthBehaviour behaviour;

        override public void Init()
        {
            base.Init();
            behaviour = new HealthBehaviour(HealthData, this, input);
        }

        override public void Tick()
        {
            behaviour.Tick();
        }

        public void Destroy()
        {
            var actor = TheOneWhoDies.GetComponent<Actor>();
            if (actor != null)
            {
                GameServices.LevelTicker.RequestDestroy(actor);
            }
        }
    }
}