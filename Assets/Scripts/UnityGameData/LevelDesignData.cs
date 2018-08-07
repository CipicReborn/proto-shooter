using UnityEngine;

namespace UnityGameData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "GD/Level/New LevelData", order = 1)]
    public class LevelDesignData : ScriptableObject
    {

        public int Speed;
        public int LengthInSeconds;
    }
}