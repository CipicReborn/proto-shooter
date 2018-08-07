using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BoundsPositioner : MonoBehaviour {

    public Camera Camera;

    public Transform TopLeft;
    public Transform MidLeft;
    public Transform BottomLeft;
    public Transform TopRight;
    public Transform MidRight;
    public Transform BottomRight;
    public Transform TopCenter;
    public Transform BottomCenter;

    public bool Reset;

    private Boundaries boundaries;

    void Update () {
		if (Reset)
        {
            Reset = false;
            boundaries = GameServices.Boundaries.GetBoundaries(true);
            PositionBounds();
            PositionCamera();
        }
    }



    private void PositionBounds()
    {
        TopLeft.position = new Vector2(boundaries.Left, boundaries.Top);
        MidLeft.position = new Vector2(boundaries.Left, boundaries.Mid);
        BottomLeft.position = new Vector2(boundaries.Left, boundaries.Bottom);

        TopRight.position = new Vector2(boundaries.Right, boundaries.Top);
        MidRight.position = new Vector2(boundaries.Right, boundaries.Mid);
        BottomRight.position = new Vector2(boundaries.Right, boundaries.Bottom);

        TopCenter.position = new Vector2(boundaries.Center, boundaries.Top);
        BottomCenter.position = new Vector2(boundaries.Center, boundaries.Bottom);
    }

    private void PositionCamera()
    {
        Camera.transform.position = new Vector3(boundaries.Center, boundaries.Mid, Camera.transform.position.z);
    }
}
