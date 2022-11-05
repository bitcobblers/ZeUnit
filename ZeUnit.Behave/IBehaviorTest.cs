namespace ZeUnit.Behave
{
    public interface IBehaviorTest<IState>
    {
        string Message { get; }

        ZeResult Do(IState state);
    }
}