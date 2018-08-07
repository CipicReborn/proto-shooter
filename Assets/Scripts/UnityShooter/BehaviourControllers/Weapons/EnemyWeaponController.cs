using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Weapons;

namespace UnityShooter
{
    public class EnemyWeaponController : AudioGraphicBehaviourController<bool>
    {
        public override string ObjectName { get { return transform.parent.name + " - " + gameObject.name; } }

        [Header("Settings")]
        [SerializeField]
        private GameObject BulletPrefab;
        [SerializeField]
        private IWeaponData WeaponData;
        [SerializeField]
        private Transform[] Muzzles;

        override public void Init()
        {
            base.Init();
            weaponBehaviour = new WeaponBehaviour(Muzzles, BulletPrefab, WeaponData, new AutoFireInput(), this);
        }

        override public void Tick()
        {
            weaponBehaviour.Tick();
        }

        private WeaponBehaviour weaponBehaviour;
    }
}