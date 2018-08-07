using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTime : MonoBehaviour {

    private void OnGUI()
    {
        var time = Time.time.ToString();
        GUILayout.Label(time);
    }
}
