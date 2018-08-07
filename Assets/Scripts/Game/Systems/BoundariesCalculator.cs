using UnityEngine;

public class BoundariesCalculator
{
    private Boundaries boundaries;
    private Camera Camera;

    public void SetCamera(Camera camera)
    {
        Camera = camera;
    }

    public void Recalculate ()
    {
        CalculateRatio();
        CalculateHeight(Camera.fieldOfView, Camera.transform.position.z);
        CalculateWidth();

        boundaries = new Boundaries()
        {
            Left = 0,
            Center = halfWidth,
            Right = 2 * halfWidth,
            Top = halfHeight,
            Mid = 0,
            Bottom = -halfHeight
        };
    }

    public Boundaries GetBoundaries(bool recalculate = false)
    {
        if (recalculate)
        {
            Recalculate();
        }

        return boundaries;
    }

    public Boundaries GetBoundaries(Vector2 margin, bool recalculate = false)
    {
        if (recalculate)
        {
            Recalculate();
        }

        return AddMargin(boundaries, margin);
    }

    private float screenRatio;
    private float halfHeight;
    private float halfWidth;

    private void CalculateRatio()
    {
        screenRatio = (float)Screen.width / Screen.height;
    }

    private void CalculateHeight(float fieldOfView, float distanceFromOrigin)
    {
        float distance = Mathf.Abs(distanceFromOrigin);
        halfHeight = distance * Mathf.Tan(fieldOfView * Mathf.Deg2Rad / 2.0f);
    }

    private void CalculateWidth()
    {
        halfWidth = halfHeight * screenRatio;
    }

    private Boundaries AddMargin (Boundaries pBoundaries, Vector2 margin)
    {
        var boundaries = new Boundaries(pBoundaries);
        boundaries.Bottom -= margin.y;
        boundaries.Top += margin.y;
        boundaries.Left -= margin.x;
        boundaries.Right += margin.x;
        return boundaries;
    }
}
