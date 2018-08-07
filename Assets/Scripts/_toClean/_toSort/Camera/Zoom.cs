using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Zoom : MonoBehaviour {

    [Range(0,10)]
    public int DesiredZoomLevel;

    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Camera nearCamera;
    [SerializeField]
    private Camera farCamera;

    private int currentZoomLevel;

    private void Awake()
    {

    }


    private void Start()
    {
        ChangeZoom();
    }


    private void Update()
    {
        if (DesiredZoomLevel != currentZoomLevel)
            ChangeZoom();
    }

    public float GetFieldOfView(float orthoSize, float distanceFromOrigin)
    {
        float distance = Mathf.Abs(distanceFromOrigin);

        float fieldOfView = Mathf.Atan(orthoSize / distance) * Mathf.Rad2Deg * 2f;
        return fieldOfView;
    }

    private void ChangeZoom()
    {

        mainCamera.orthographicSize = 30 - DesiredZoomLevel * 2;
        var distanceFromOrigin = transform.localPosition.magnitude;
        UpdateNearFar(distanceFromOrigin);
        var fov = GetFieldOfView(mainCamera.orthographicSize, distanceFromOrigin);
        farCamera.fieldOfView = fov;
        nearCamera.fieldOfView = fov;

        currentZoomLevel = DesiredZoomLevel;
    }

    private void UpdateNearFar(float distanceFromOrigin)
    {
        farCamera.nearClipPlane = distanceFromOrigin;
        farCamera.farClipPlane = mainCamera.farClipPlane;
        nearCamera.farClipPlane = distanceFromOrigin;
        nearCamera.nearClipPlane = mainCamera.nearClipPlane;
    }
}
