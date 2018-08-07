using UnityEngine;

namespace Game.Behaviour.Movement
{
    public class PlayerMoveBehaviour : AudioGraphicBehaviour<ProbedDirectionInput, Vector2>
    {
        public PlayerMoveBehaviour(Transform transformToMove, Boundaries boundaries, ISpeedValue speed, ISpeedValue blockerSpeed, IInput<ProbedDirectionInput> input, IAudioGraphicBehaviourController<Vector2> controller) :
            base(input, controller)
        {
            inputModule = input;
            this.transformToMove = transformToMove;
            this.speed = speed;
            this.blockerSpeed = blockerSpeed;
            this.boundaries = boundaries;
        }

        override protected Vector2 GetResult(ProbedDirectionInput input)
        {
            var oldPos = transformToMove.position;

            Vector3 move = GetMove(input);
            ApplyEnvironment(input, ref move);
            ApplyBoundaries(ref move);
            transformToMove.position += move;
            if (controller.EnableDebugLogs)
                Debug.Log("Applied " + move.ToString());
            return move.normalized;
        }

        private ISpeedValue speed;
        private ISpeedValue blockerSpeed;
        private Transform transformToMove;
        private Boundaries boundaries;

        private Vector3 GetMove(ProbedDirectionInput input)
        {
            return input.Direction * speed.Value * Time.deltaTime;
        }

        private void ApplyEnvironment(ProbedDirectionInput input, ref Vector3 move)
        {
            if (input.BlockedMove.Front)
            {
                var blockerMoveX = -1.0f * blockerSpeed.Value * Time.deltaTime;

                if (move.x > 0)
                    move.x = 0;
                
                move.x += blockerMoveX;
            }
            if (input.BlockedMove.Rear && move.x < 0)
            {
                move.x = 0;
            }
            if (input.BlockedMove.Up && move.y > 0)
            {
                move.y = 0;
            }
            if (input.BlockedMove.Down && move.y < 0)
            {
                move.y = 0;
            }
        }

        private void ApplyBoundaries(ref Vector3 move)
        {
            var pos = transformToMove.position;
            var posAfterMove = transformToMove.position + move;
            if (posAfterMove.x < boundaries.Left)
            {
                move.x = boundaries.Left - pos.x;
            }
            if (posAfterMove.x > boundaries.Right)
            {
                move.x = boundaries.Right - pos.x;
            }
            if (posAfterMove.y < boundaries.Bottom)
            {
                move.y = boundaries.Bottom - pos.y;
            }
            if (posAfterMove.y > boundaries.Top)
            {
                move.y = boundaries.Top - pos.y;
            }
        }
    }
}