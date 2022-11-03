namespace ZeUnit.Behave
{
    public interface IBehaviorAction<IState>
    {
        string Message { get; }
        //IEnumerable<(string, object)> Do(IState state);
        void Do(IState state);
    }
}