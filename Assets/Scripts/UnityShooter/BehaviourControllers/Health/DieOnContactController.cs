using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Health;
using System;

namespace UnityShooter
{
    public class DieOnContactController : BehaviourController, IHealthSystemController
    {
        public override string ObjectName { get { return transform.parent.name + " - DieOnContactController"; } }
        public IInput<DamagersCollided> input;

        [SerializeField]
        private GameObject TheOneWhoDies;

        public int CurrentHealth { set { } }

        public override void Init()
        {
            behaviour = new DieOnContactBehaviour(input, this);
        }

        public override void Tick()
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

        public void TriggerAudioEffect(HealthAfterDamage behaviourResult)
        {
        }

        public void TriggerGraphicEffect(HealthAfterDamage behaviourResult)
        {
        }

        private DieOnContactBehaviour behaviour;
    }
}