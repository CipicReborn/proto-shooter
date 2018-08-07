using UnityEngine;
using Game.Behaviour;

namespace UnityShooter
{
    public class PlayerFireInput : IInput<bool>
    {
        public bool Read()
        {
            return Input.GetButton("Fire");
        }
    }
}