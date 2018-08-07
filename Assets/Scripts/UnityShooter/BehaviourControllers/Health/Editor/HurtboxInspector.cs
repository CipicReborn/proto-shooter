using UnityEditor;
using UnityEngine;
using UnityShooter;

[CustomEditor(typeof(Hurtbox))]
public class HurtboxInspector : Editor
{
    int layer;
    GUILayoutOption[] options;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Hurtbox hitbox = (Hurtbox)target;
        hitbox.gameObject.layer = EditorGUILayout.LayerField(hitbox.gameObject.layer, options);
    }
}