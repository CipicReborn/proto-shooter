using System.Collections.Generic;
using UnityEngine;
using UnityGameData;
using UnityShooter;

public class Enemy : Launchable
{
    [Header("Body & Health")]
    public HealthSystem HealthSystem;

    [Header("Movement")]
    public List<MovePattern> moveData;
    public EnemyMoveController moveController;

    [Header("Weaponry")]
    public List<Weapon> Weapons;

    [Header("Audio")]
    public GameObject WeaponA;
    public GameObject WeaponB;

    [Header("Model")]
    public GameObject Model;




    private ScriptedMovementInput moveBehaviour;

    private void Awake()
    {
        //moveBehaviour = new ScriptedMovement(transform, moveData);
        moveController.Init();
    }

    private void Update()
    {
        UpdateMove();
        UpdateHealth();
        UpdateWeapons();
    }

    private void UpdateHealth()
    {
        //HealthSystem.Tick();
    }

    private void UpdateMove()
    {
        //moveBehaviour.Tick();
        moveController.Tick();
    }

    private void UpdateWeapons()
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].TriggerFire();
        }
    }





    // nope
    public override void Launch(float speed, Vector2 direction)
    {
    }

}