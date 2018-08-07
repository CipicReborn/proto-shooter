using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Health;
using System;

namespace UnityShooter
{
    public class UndamageableController : AudioGraphicBehaviourController<HealthAfterDamage> , IHealthSystemController
    {
        [Header("Settings")]
        public Hitbox Hitbox;

        public override string ObjectName { get { return transform.parent.name + " - UndamageableController"; } }


        override public void Init()
        {
            base.Init();
            behaviour = new UndamageableBehaviour(Hitbox, this);
        }

        override public void Tick()
        {
            behaviour.Tick();
        }

        public void Destroy() { }

        private UndamageableBehaviour behaviour;
    }
}