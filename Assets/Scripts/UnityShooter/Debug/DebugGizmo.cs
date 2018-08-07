using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DebugGizmo : MonoBehaviour {

    public Color Color;
    public float Size;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color;
        Gizmos.DrawSphere(transform.position, Size);
    }
}
