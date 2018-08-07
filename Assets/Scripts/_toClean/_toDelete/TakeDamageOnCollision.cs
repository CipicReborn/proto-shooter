using UnityEngine;
using Sirenix.OdinInspector;
using Game;
using System;

public class TakeDamageOnCollision : SerializedMonoBehaviour {

    public IDamageable Target;

    private void OnCollisionEnter(Collision collision)
    {
        Target.CollisionDamage(collision.collider.gameObject);
    }

}
