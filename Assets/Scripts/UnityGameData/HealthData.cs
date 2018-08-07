using UnityEngine;
using Game.Behaviour.Health;
using System;

namespace UnityGameData
{
    [CreateAssetMenu(fileName = "HealthSystem", menuName = "GD/Health/New HealthSystem", order = 1)]
    public class HealthData : ScriptableObject, IHealthData
    {
        public int MaxHealthPoints;
        int IHealthData.MaxHealthPoints { get { return MaxHealthPoints; } }

        public float DelayBeforeDestruction;
        float IHealthData.DelayBeforeDestruction { get { return DelayBeforeDestruction; } }
    }
}