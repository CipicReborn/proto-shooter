using UnityEngine;

public class DeathByBoundaries : MonoBehaviour {

    public GameObject Target;
    public Vector2 Margin;

    void Awake()
    {
        boundaries = GameServices.Boundaries.GetBoundaries();
    }

    void Update () {

        var pos = transform.position;
        if (pos.y < (boundaries.Bottom - Margin.y) || pos.y > (boundaries.Top + Margin.x))
        {
            Destroy(Target);
            return;
        }
        if (pos.x < (boundaries.Left - Margin.x) || pos.x > (boundaries.Right + Margin.x))
        {
            Destroy(Target);
            return;
        }

    }

    private Boundaries boundaries;
}
