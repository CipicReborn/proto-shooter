using UnityEngine;
using Game.Behaviour.Weapons;
using UnityGameData;
using UnityShooter;

public class Weapon : MonoBehaviour
{
    public WeaponData WeaponData;
    public Transform Muzzle;
    public WeaponAudioFeedback weaponAudioFeedback;
    public Launchable BulletPrefab;

    public void TriggerFire()
    {
        if (WeaponHasCooledDown())
        {
            Fire();
            if (weaponAudioFeedback != null)
                weaponAudioFeedback.Fire();
        }
    }

    private float gunReadyTime;
    private int currentBurstIndex = 1;

    private bool WeaponHasCooledDown()
    {
        return Time.time > gunReadyTime;
    }

    private void Fire()
    {
        var bullet = Instantiate(BulletPrefab);
        bullet.transform.position = Muzzle.position;
        bullet.Launch(WeaponData.BulletSpeed, Muzzle.transform.forward);
        gunReadyTime = CalculateCooldown();
    }

    private float CalculateCooldown()
    {
        if (WeaponData.Mode == eWeaponMode.Auto)
        {
            return Time.time + WeaponData.CooldownDuration;
        }
        else if (WeaponData.Mode == eWeaponMode.Burst)
        {
            if (currentBurstIndex < WeaponData.BurstSize)
            {
                currentBurstIndex++;
                return Time.time + WeaponData.CooldownDuration;
            }

            currentBurstIndex = 1;
            return Time.time + WeaponData.BurstCooldownDuration;
        }
        return 0;
    }
}
