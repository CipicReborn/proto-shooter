namespace Game.Behaviour
{
    public interface IFeedbackEffect<T>
    {
        void Tick(T gameOutput);
    }
}
