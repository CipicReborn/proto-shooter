using UnityEngine;

public class DeathByCollision : MonoBehaviour {

    public GameObject Target;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(Target);
    }
}
