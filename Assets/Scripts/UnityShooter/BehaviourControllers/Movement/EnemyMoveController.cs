using System.Collections.Generic;
using UnityEngine;
using Game.Behaviour;
using Game.Behaviour.Movement;
using UnityGameData;

namespace UnityShooter
{
    public class EnemyMoveController : AudioGraphicBehaviourController<Vector2>
    {
        public override string ObjectName { get { return transform.parent.name + " - EnemyMoveController"; } }

        [Header("Move Settings")]
        public Transform TransformToMove;
        [Space(10)]
        public List<MovePattern> moveData;

        override public void Init()
        {
            base.Init();
            moveAI = new ScriptedMovementInput(TransformToMove, moveData);
            moveBehaviour = new ScreenSpaceMoveBehaviour(transform.parent, moveAI, moveAI, this);
        }

        override public void Tick()
        {
            moveBehaviour.Tick();
        }

        private ScreenSpaceMoveBehaviour moveBehaviour;
        private ScriptedMovementInput moveAI;
    }
}