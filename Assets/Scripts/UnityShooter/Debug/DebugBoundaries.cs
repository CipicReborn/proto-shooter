using UnityEngine;
using UnityGameData;

[ExecuteInEditMode]
public class DebugBoundaries : MonoBehaviour {

    [Header("Size")]
    public IntValue ScrollSpeed;
    public IntValue LevelLengthInSeconds;
    [Header("Visualisation")]
    public Color Color;
    public bool Plain;
    public Color PlainColor;

    private float width;
    private float height;
    private Vector3 center;
    private Vector3 size;
    private Vector3 TopLeft = new Vector3();
    private Vector3 BottomLeft = new Vector3();
    private Vector3 TopRight = new Vector3();
    private Vector3 BottomRight = new Vector3();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color;
        CalculateBoundaries();
        Gizmos.DrawLine(TopLeft, TopRight);
        Gizmos.DrawLine(BottomLeft, BottomRight);
        Gizmos.DrawLine(TopLeft, BottomLeft);
        Gizmos.DrawLine(TopRight, BottomRight);
        if (Plain)
        {
            Gizmos.color = PlainColor;
            center = new Vector3((TopRight.x + TopLeft.x) / 2.0f, 0f, 5.0f);
            size = new Vector3(width, height, 1.0f);
            Gizmos.DrawCube(center, size);
        }
    }

    private void CalculateBoundaries()
    {
        width = ScrollSpeed.Value * LevelLengthInSeconds.Value;
        height = GameServices.Boundaries.GetBoundaries().Height;

        TopLeft.y = transform.position.y + height / 2.0f;
        TopRight.y = transform.position.y + height / 2.0f;

        BottomLeft.y = transform.position.y - height / 2.0f;
        BottomRight.y = transform.position.y - height / 2.0f;

        TopRight.x = transform.position.x + width;
        BottomRight.x = transform.position.x + width;

        TopLeft.x = transform.position.x;
        BottomLeft.x = transform.position.x;

    }
}
