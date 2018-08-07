using Game.Behaviour.Movement;
using UnityEngine;

namespace UnityGameData
{
    [CreateAssetMenu(fileName = "SpeedData", menuName = "GD/Movement/New SpeedData", order = 1)]
    public class SpeedData : ScriptableObject, ISpeedValue
    {
        public float Speed;
        float ISpeedValue.Value { get { return Speed; } }
    }
}