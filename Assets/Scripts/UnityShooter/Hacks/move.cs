using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public Vector3 Move;
	
	void Update () {
        transform.position += Move;
    }
}
