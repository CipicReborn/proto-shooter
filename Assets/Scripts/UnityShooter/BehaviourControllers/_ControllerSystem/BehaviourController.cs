using UnityEngine;
using Sirenix.OdinInspector;
using Game.Behaviour;

namespace UnityShooter
{
    public abstract class BehaviourController : SerializedMonoBehaviour, IBehaviourController, IActorAbility
    {
        // IBehaviourController
        public abstract string ObjectName { get; } // { return transform.parent.name + " - BaseController"; }
        public bool EnableDebugLogs { get { return enableDebugLogs; } }

        [SerializeField]
        private bool enableDebugLogs;


        // IActorAbility
        public abstract void Init ();
        public abstract void Tick ();
    }
}