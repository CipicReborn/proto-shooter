using UnityEngine;

public interface IScrollingLayer
{
    Vector2 ScrollingSpeed { get; set; }
    void AddAtPosition(Transform element, Vector3 positionInWorldSpace);
    void Tick(float deltaTime);
    Vector2 GetDistanceScrolled();
}
