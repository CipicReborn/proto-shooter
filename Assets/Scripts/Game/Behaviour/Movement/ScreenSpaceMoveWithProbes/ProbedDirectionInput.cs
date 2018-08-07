using UnityEngine;

namespace Game.Behaviour.Movement
{
    public struct ProbedDirectionInput
    {
        public Vector2 Direction;
        public PathblockResult BlockedMove;

        public override string ToString()
        {
            return "Direction " + Direction.ToString() + ", Probes : { Front : " + BlockedMove.Front + ", Rear : " + BlockedMove.Rear + ", Up : " + BlockedMove.Up + ", Down : " + BlockedMove.Down + "}" ;
        }
    }
}