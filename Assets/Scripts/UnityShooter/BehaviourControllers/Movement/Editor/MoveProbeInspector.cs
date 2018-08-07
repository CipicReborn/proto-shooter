using UnityEditor;
using UnityShooter;

[CustomEditor(typeof(MoveProbe))]
public class MoveProbeInspector : Editor
{
    int layer;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MoveProbe probe = (MoveProbe)target;
        probe.gameObject.layer = EditorGUILayout.LayerField(probe.gameObject.layer);
    }
}