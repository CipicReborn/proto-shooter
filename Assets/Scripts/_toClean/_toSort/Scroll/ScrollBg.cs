using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBg : Layer, IScrollingLayer {

    public Vector2 Size;
    private int childCount;
    private void Awake()
    {
        childCount = transform.childCount;
    }

    protected override void TickOperation(Transform child)
    {
        if (child.position.x < -Size.x)
        {
            child.position += (Vector3) Size * childCount;
        }
    }
}
