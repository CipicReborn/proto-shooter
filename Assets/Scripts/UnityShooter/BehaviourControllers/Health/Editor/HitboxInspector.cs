using UnityEditor;
using UnityShooter;

[CustomEditor(typeof(Hitbox))]
public class HitboxInspector : Editor
{
    int layer;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Hitbox hitbox = (Hitbox)target;
        hitbox.gameObject.layer = EditorGUILayout.LayerField(hitbox.gameObject.layer);
    }
}
