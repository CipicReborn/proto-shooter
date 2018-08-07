using UnityEngine;

public class EnemyLauncher : MonoBehaviour {

    Weapon Weapon;
    public float PositionChangePeriod;
    public float RandomRadius;
    public bool EnableLateralRandom;
    public float MinimumStep;

	void Awake () {
        Weapon = GetComponent<Weapon>();
        initialPosition = transform.position;
    }
	
	
	void Update () {
        Weapon.TriggerFire();

        if (ItIsTimeForNewPosition())
        {
            SetNewRandomPosition();
        }
	}

    private float nextChangeTime;
    private Vector3 initialPosition;

    private bool ItIsTimeForNewPosition()
    {
        return Time.time > nextChangeTime;
    }

    private void SetNewRandomPosition()
    {
        nextChangeTime = Time.time + PositionChangePeriod;
        var randomOffset = new Vector3(0, Random.Range(-1.0f, 1.0f) * RandomRadius, 0);
        if (EnableLateralRandom)
        {
            randomOffset.x = Random.Range(-1.0f, 1.0f) * RandomRadius;
        }

        if (randomOffset.magnitude < MinimumStep)
        {
            randomOffset = randomOffset.normalized * MinimumStep;
        }

        transform.position = initialPosition + randomOffset;
    }
}
