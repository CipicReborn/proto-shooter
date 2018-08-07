using UnityEngine;

namespace Game.Behaviour.Weapons
{
    public class WeaponBehaviour : AudioGraphicBehaviour<bool, bool>
    {
        public WeaponBehaviour(Transform[] muzzles, GameObject bulletPrefab, IWeaponData data, IInput<bool> input, IAudioGraphicBehaviourController<bool> controller) :
            base(input, controller)
        {
            weaponData = data;
            this.muzzles = muzzles;
            this.bulletPrefab = bulletPrefab;
        }

        override protected bool GetResult(bool input)
        {
            if (input)
            {
                return TriggerFire();
            }
            return false;
        }

        private Transform[] muzzles;
        private GameObject bulletPrefab;
        private IWeaponData weaponData;
        private float gunReadyTime;
        private int currentBurstIndex = 1;

        private bool TriggerFire()
        {
            if (WeaponHasCooledDown())
            {
                Fire();
                return true;
            }
            return false;
        }

        private bool WeaponHasCooledDown()
        {
            return Time.time > gunReadyTime;
        }

        private void Fire()
        {
            for (int i = 0; i < muzzles.Length; i++)
            {
                CreateBulletAt(muzzles[i]);
            }
            gunReadyTime = CalculateCooldown();
        }

        private void CreateBulletAt(Transform muzzle)
        {
            var bullet = GameObject.Instantiate(bulletPrefab);
            bullet.transform.position = muzzle.position;
            bullet.transform.forward = muzzle.forward;
        }

        private float CalculateCooldown()
        {
            if (weaponData.Mode == eWeaponMode.Auto)
            {
                return Time.time + weaponData.CooldownDuration;
            }
            else if (weaponData.Mode == eWeaponMode.Burst)
            {
                if (currentBurstIndex < weaponData.BurstSize)
                {
                    currentBurstIndex++;
                    return Time.time + weaponData.CooldownDuration;
                }

                currentBurstIndex = 1;
                return Time.time + weaponData.BurstCooldownDuration;
            }
            return 0;
        }
    }
}