using UnityEngine;

namespace Game.Behaviour.Movement
{
    public class ScreenSpaceMoveBehaviour : AudioGraphicBehaviour<Vector2, Vector2>
    {
        public ScreenSpaceMoveBehaviour(Transform transformToMove, ISpeedValue data, IInput<Vector2> input, IAudioGraphicBehaviourController<Vector2> controller) : base(input, controller)
        {
            this.transformToMove = transformToMove;
            this.data = data;
        }

        override protected Vector2 GetResult(Vector2 input)
        {
            Vector3 move = input * data.Value * Time.deltaTime;
            transformToMove.position += move;
            return move.normalized;
        }

        private Transform transformToMove;
        private ISpeedValue data;
    }
}