using System;
using Game.Behaviour.Weapons;
using UnityEngine;

namespace UnityGameData
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "GD/Weapons/New WeaponData", order = 1)]
    [Serializable]
    public class WeaponData : ScriptableObject, IWeaponData
    {
        [Header("Mode")]
        public eWeaponMode Mode;
        
        public float BurstCooldownDuration;
        public int BurstSize;

        [Header("Ammo")]
        public float CooldownDuration;
        public float BulletSpeed;

        eWeaponMode IWeaponData.Mode { get { return Mode; } }
        float IWeaponData.BurstCooldownDuration { get { return BurstCooldownDuration; } }
        int IWeaponData.BurstSize { get { return BurstSize; } }
        float IWeaponData.CooldownDuration { get { return CooldownDuration; } }
        float IWeaponData.BulletSpeed { get { return BulletSpeed; } }
    }
}