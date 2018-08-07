using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Warp : MonoBehaviour {

    [HideInInspector]
    public WarpSystem System;
    [HideInInspector]
    public string Name;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            System.WarpOut(other.gameObject.transform, Name);
        }
    }


}
