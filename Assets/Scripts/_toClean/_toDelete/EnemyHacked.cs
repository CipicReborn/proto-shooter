using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHacked : MonoBehaviour {

    public Bullet prefab;
    public float CooldownDuration;
    public float BulletSpeed;
    public bool burstShot;
    public Transform Muzzle;

    public int shotCountInBurst;
    public float burstCoolDown;

    private bool weaponHasCooledDown = true;
    private float coolTime;

    public bool PlayerIsInRange;

    private void Awake()
    {
        GetComponentInChildren<PlayerDetector>().Owner = this;
    }

    void Start () {
		
	}


	void Update () {
        Move();
        TriggerShoot();
	}

    private void Move()
    {

    }

    private void TriggerShoot()
    {
        if (weaponHasCooledDown && PlayerIsInRange)
        {
            Shoot();
        }
        else
        {
            Cooldown();
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate<Bullet>(prefab, Muzzle);
        bullet.Launch(BulletSpeed, Vector3.left);
        InitCooldown();
    }

    private void Cooldown()
    {
        coolTime += Time.deltaTime;
        if (coolTime > GetCooldownDuration())
        {
            weaponHasCooledDown = true;
        }
    }

    private int shotCount;

    private void InitCooldown()
    {
        if (shotCount >= shotCountInBurst)
            shotCount = 0;
        shotCount++;
        coolTime = 0;
        weaponHasCooledDown = false;
    }

    private float GetCooldownDuration() {
        if (!burstShot || shotCount < shotCountInBurst)
        {
            return CooldownDuration;
        }
        
        return burstCoolDown;
    }
}
