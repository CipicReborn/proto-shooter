using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RandomRotationOnStart : MonoBehaviour {

    Rigidbody rb;
    public float Force;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddTorque(Random.onUnitSphere * Force);
    }

}
