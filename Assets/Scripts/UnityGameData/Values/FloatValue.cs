using UnityEngine;

namespace UnityGameData
{
    [CreateAssetMenu(fileName = "NewFloat", menuName = "GD/Values/New Float", order = 2)]
    public class FloatValue : ScriptableObject
    {
        public float Value;
    }
}
