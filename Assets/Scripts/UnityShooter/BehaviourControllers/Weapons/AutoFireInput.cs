using Game.Behaviour;

namespace UnityShooter
{
    public class AutoFireInput : IInput<bool>
    {
        public bool Read()
        {
            return true;
        }
    }
}