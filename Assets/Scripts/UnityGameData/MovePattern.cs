using UnityEngine;

namespace UnityGameData
{

    [CreateAssetMenu(fileName = "MovePattern", menuName = "GD/Movement/New MovePattern", order = 1)]
    public class MovePattern : ScriptableObject
    {
        [Header("Cycle")]
        public float Duration;
        public bool Loop;

        [Header("Speed")]
        public float BaseSpeed;
        public AnimationCurve SpeedOverDuration;

        [Header("Direction")]
        public AnimationCurve xOverDuration;
        public AnimationCurve yOverDuration;
    }
}