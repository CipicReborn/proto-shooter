using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Game;

namespace UnityShooter
{
    public class WeaponsController : SerializedMonoBehaviour, IActorAbility
    {
        [SerializeField]
        private List<IActorAbility> WeaponControllers;

        public void Init()
        {
            for (int i = 0; i < WeaponControllers.Count; i++)
            {
                WeaponControllers[i].Init();
            }
        }

        public void Tick()
        {
            for (int i = 0; i < WeaponControllers.Count; i++)
            {
                WeaponControllers[i].Tick();
            }
        }
    }
}