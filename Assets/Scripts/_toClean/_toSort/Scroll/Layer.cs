using UnityEngine;

public class Layer : MonoBehaviour, IScrollingLayer
{
    public Vector2 ScrollingSpeed { get; set; }

    public void AddAtPosition(Transform element, Vector3 positionInWorldSpace)
    {
        element.position = positionInWorldSpace;
        element.SetParent(transform, true);

        var pos = element.localPosition;
        pos.z = 0;
        element.localPosition = pos;
    }

    public Vector2 GetDistanceScrolled()
    {
        return distanceScrolled;
    }

    public void Tick(float deltaTime)
    {
        Vector2 distance = -ScrollingSpeed * deltaTime;
        distanceScrolled -= distance;
        transform.position += (Vector3)distance;
        for (int i = 0; i < transform.childCount; i++)
        {
            TickOperation(transform.GetChild(i));
        }
    }

    protected Vector2 distanceScrolled = new Vector2();

    virtual protected void TickOperation (Transform child) { }
}

