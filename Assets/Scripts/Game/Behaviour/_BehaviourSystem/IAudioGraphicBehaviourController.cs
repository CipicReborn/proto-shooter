namespace Game.Behaviour
{
    public interface IAudioGraphicBehaviourController<OutputType> : IBehaviourController
    {
        void TriggerAudioEffect(OutputType behaviourResult);
        void TriggerGraphicEffect(OutputType behaviourResult);
    }
}
