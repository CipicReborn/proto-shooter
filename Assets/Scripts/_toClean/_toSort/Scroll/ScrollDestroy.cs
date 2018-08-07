using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDestroy : Layer, IScrollingLayer {

    protected override void TickOperation(Transform child)
    {
        base.TickOperation(child);
        if (child.position.x < -200)
        {
            Destroy(child.gameObject);
        }
    }
}
