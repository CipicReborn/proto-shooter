using UnityEngine;

namespace UnityShooter
{
    [RequireComponent(typeof(Rigidbody))]
    public class Hurtbox : CollisionBox
    {
        private void OnValidate()
        {
            var rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    Debug.Log(transform.parent.parent.name + " has been collided by " + collision.collider.gameObject.name);
        //}
    }
}