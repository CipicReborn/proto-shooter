using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Movement;
using System;

namespace UnityShooter
{
    public class PlayerMoveController : AudioGraphicBehaviourController<Vector2>
    {
        public override string ObjectName { get { return transform.parent.name + " - PlayerMoveController"; } }

        public override void Init()
        {
            base.Init();
            var input = new PlayerMoveInput(FrontProbe, RearProbe, UpProbe, DownProbe);
            var boundaries = GameServices.Boundaries.GetBoundaries(-MarginWithinBoundaries);

            moveBehaviour = new PlayerMoveBehaviour(TransformToMove, boundaries, Data, DecorSpeed, input, this);
        }

        public override void Tick()
        {
            moveBehaviour.Tick();
        }

        [Header("Speeds")]
        [SerializeField]
        private Transform TransformToMove;
        [SerializeField]
        private Vector2 MarginWithinBoundaries;

        [Header("Pathblocks Probes")]
        [SerializeField]
        private MoveProbe FrontProbe;
        [SerializeField]
        private MoveProbe RearProbe;
        [SerializeField]
        private MoveProbe UpProbe;
        [SerializeField]
        private MoveProbe DownProbe;

        [Header("Speeds")]
        [SerializeField]
        private ISpeedValue Data;
        [SerializeField]
        private ISpeedValue DecorSpeed;



        private PlayerMoveBehaviour moveBehaviour;
    }
}