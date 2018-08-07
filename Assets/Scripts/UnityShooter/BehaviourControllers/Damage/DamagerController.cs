using UnityEngine;
using Game.Behaviour.Damage;
using System;

namespace UnityShooter
{
    public class DamagerController : BehaviourController
    {
        public override string ObjectName { get { return transform.parent.name + " - DamagerController"; } }

        [Header("Settings")]
        [SerializeField]
        private IDamageData Data;
        [SerializeField]
        private Hurtbox Hurtbox;

        override public void Init()
        {
            behaviour = new Damager(Data, this);
            if (Hurtbox == null)
            {
                throw new System.Exception("A DamageController must have a Hurtbox");
            }
        }

        public override void Tick() { }

        public Damager GetDamager()
        {
            return behaviour;
        }

        private Damager behaviour;
    }
}