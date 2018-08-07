

namespace Game.Behaviour
{
    public abstract class AudioGraphicBehaviour<InputType, OutputType> : Behaviour<InputType, OutputType>
    {
        public AudioGraphicBehaviour (IInput<InputType> input, IAudioGraphicBehaviourController<OutputType> controller) : base(input, controller)
        {
            this.controller = controller;
        }

        override protected void Feedback ()
        {
            controller.TriggerAudioEffect(result);
            controller.TriggerGraphicEffect(result);
        }

        private new IAudioGraphicBehaviourController<OutputType> controller;
    }
}
