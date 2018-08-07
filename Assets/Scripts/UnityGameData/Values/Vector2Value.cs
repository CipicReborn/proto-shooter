using UnityEngine;

namespace UnityGameData
{
    [CreateAssetMenu(fileName = "NewVector2", menuName = "GD/Values/New Vector2", order = 3)]
    public class Vector2Value : ScriptableObject
    {
        public Vector2 Value;
    }
}