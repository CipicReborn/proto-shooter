using UnityEngine;
using Game.Behaviour.Damage;

namespace UnityGameData
{
    [CreateAssetMenu(fileName = "Damage", menuName = "GD/Damage/New DamageData", order = 1)]
    public class DamageData : ScriptableObject, IDamageData
    {

        public int Damage;
        int IDamageData.Damage { get { return Damage;} }
    }
}