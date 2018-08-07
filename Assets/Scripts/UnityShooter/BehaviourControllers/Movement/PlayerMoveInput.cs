using UnityEngine;
using Game.Behaviour.Movement;

namespace UnityShooter
{
    public class PlayerMoveInput : IPlayerMoveInput
    {
        public PlayerMoveInput (MoveProbe front, MoveProbe rear, MoveProbe up, MoveProbe down)
        {
            frontProbe = front;
            rearProbe = rear;
            upProbe = up;
            downProbe = down;
        }

        private ProbedDirectionInput value = new ProbedDirectionInput();
        private MoveProbe frontProbe;
        private MoveProbe rearProbe;
        private MoveProbe upProbe;
        private MoveProbe downProbe;

        public ProbedDirectionInput Read()
        {
            value.Direction.x = Input.GetAxis("Horizontal");
            value.Direction.y = Input.GetAxis("Vertical");

            value.BlockedMove.Front = frontProbe.IsBlocked();
            value.BlockedMove.Rear = rearProbe.IsBlocked();
            value.BlockedMove.Up = upProbe.IsBlocked();
            value.BlockedMove.Down = downProbe.IsBlocked();
            return value;
        }
    }
}