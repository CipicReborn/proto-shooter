using UnityEngine;
using Game.Behaviour;
using UnityShooter;

public class PlayerShoot : MonoBehaviour {

    public bool AutoShoot;
    public Weapon Weapon;

    private IInput<bool> fireInput;

    private void Awake()
    {
        fireInput = new PlayerFireInput();
    }

    void Update () {
		if (AutoShoot || fireInput.Read())
        {
            Weapon.TriggerFire();
        }
	}
}
