using System;
using Game.Behaviour;
using UnityEngine;

namespace UnityShooter
{
    public abstract class AudioGraphicBehaviourController<BehaviourOutputType> : BehaviourController, IAudioGraphicBehaviourController<BehaviourOutputType>
    {
        public override void Init()
        {
            TickAudioEffect = TickNullEffect;
            TickGraphicEffect = TickNullEffect;

            if (AudioEffect != null)
            {
                TickAudioEffect = TickExistingAudioEffect;
            }
            if (GraphicEffect != null)
            {
                TickGraphicEffect = TickExistingGraphicEffect;
            }
        }

        public void TriggerAudioEffect(BehaviourOutputType behaviourResult)
        {
            TickAudioEffect(behaviourResult);
        }

        public void TriggerGraphicEffect(BehaviourOutputType behaviourResult)
        {
            TickGraphicEffect(behaviourResult);
        }


        [Header("Effects")]
        [SerializeField]
        private IFeedbackEffect<BehaviourOutputType> AudioEffect;
        [SerializeField]
        private IFeedbackEffect<BehaviourOutputType> GraphicEffect;

        // IAudioGraphicBehaviourController<BehaviourOutputType>
        private Action<BehaviourOutputType> TickAudioEffect;
        private Action<BehaviourOutputType> TickGraphicEffect;

        private void TickNullEffect (BehaviourOutputType behaviourResult) { }

        private void TickExistingAudioEffect (BehaviourOutputType behaviourResult)
        {
            AudioEffect.Tick(behaviourResult);
        }

        private void TickExistingGraphicEffect (BehaviourOutputType behaviourResult)
        {
            GraphicEffect.Tick(behaviourResult);
        }
    }
}