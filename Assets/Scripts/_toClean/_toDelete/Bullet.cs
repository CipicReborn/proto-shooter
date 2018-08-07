using UnityEngine;

[RequireComponent(typeof(DeathByCollision))]
[RequireComponent(typeof(DeathByBoundaries))]
public class Bullet: Launchable {

    override public void Launch(float speed, Vector2 direction)
    {
        Speed = speed;
        Direction = direction.normalized;
    }

    private float Speed;
    private Vector2 Direction;

    private void Update()
    {
        transform.position += (Vector3) (Direction * Speed * Time.deltaTime);
    }
}
