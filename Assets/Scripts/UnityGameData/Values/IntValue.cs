using System;
using Game.Behaviour.Movement;
using UnityEngine;

namespace UnityGameData
{
    [CreateAssetMenu(fileName = "NewInt", menuName = "GD/Values/New Int", order = 1)]
    public class IntValue : ScriptableObject, ISpeedValue
    {
        public int Value;

        float ISpeedValue.Value { get { return Value; } }
    }
}
