using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Weapons;

namespace UnityShooter
{
    public class PlayerWeaponController : AudioGraphicBehaviourController<bool>
    {
        override public string ObjectName { get { return transform.parent.parent.name + " - " + gameObject.name; } }

        [Header("Settings")]
        [SerializeField]
        private Transform[] Muzzles;
        [SerializeField]
        private GameObject BulletPrefab;
        [SerializeField]
        private IWeaponData WeaponData;

        override public void Init()
        {
            base.Init();
            weaponBehaviour = new WeaponBehaviour(Muzzles, BulletPrefab, WeaponData, new PlayerFireInput(), this);
        }

        override public void Tick()
        {
            weaponBehaviour.Tick();
        }

        private WeaponBehaviour weaponBehaviour;
    }
}