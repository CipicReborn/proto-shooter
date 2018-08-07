using UnityEngine;
using UnityGameData;

[ExecuteInEditMode]
public class TimelinePositionHelper : MonoBehaviour {

    [Header("Select a time interval for your transforms")]
    public float TimeInterval;
    [Header("Place the transforms you want to reposition")]
    public Transform[] toPosition;
    [Header("LevelScrollSpeed")]
    public IntValue ScrollSpeed;
    [Space(15)]
    public bool Set;

	void Update () {
		if (Set)
        {
            Set = false;
            SetPositions();
        }
	}

    private void SetPositions ()
    {
        var spaceInterval = TimeInterval * ScrollSpeed.Value;
        var firstPos = toPosition[0].position;
        Transform lTransform;
        Vector3 lPosition;
        for (int i = 0; i < toPosition.Length; i++)
        {
            lTransform = toPosition[i];
            lPosition = lTransform.position;
            lPosition.x = firstPos.x + spaceInterval * i;
            lTransform.position = lPosition;
        }
    }
}
