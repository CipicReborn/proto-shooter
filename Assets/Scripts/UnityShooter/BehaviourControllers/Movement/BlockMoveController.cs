using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Movement;
using UnityGameData;

namespace UnityShooter
{
    public class BlockMoveController : AudioGraphicBehaviourController<Vector2>
    {
        public override string ObjectName { get { return transform.parent.name + " - BlockMoveController"; } }

        public override void Init()
        {
            base.Init();
            move = new ConstantMove(screenSpaceDirection, Speed.Value);
            behaviour = new ScreenSpaceMoveBehaviour(transformToMove, move, move, this);
        }

        public override void Tick()
        {
            behaviour.Tick();
        }

        [Header("MoveSettings")]
        [SerializeField]
        private Transform transformToMove;
        [SerializeField]
        private IntValue Speed;
        [SerializeField]
        private Vector2 screenSpaceDirection;

        private ScreenSpaceMoveBehaviour behaviour;
        private ConstantMove move;

        private class ConstantMove : ISpeedValue, IInput<Vector2>
        {
            public ConstantMove (Vector2 direction, float speed)
            {
                this.direction = direction;
                this.speed = speed;
            }
            public float Value
            { get { return speed; } }

            public Vector2 Read() { return direction; }

            private Vector2 direction;
            private float speed;
        }
    }
}