namespace ZeUnit.Behave
{
    public interface IBehaviorAction<IState>
    {
        string Message { get; }
        void Do(IState state);
    }
}