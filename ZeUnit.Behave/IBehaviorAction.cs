namespace ZeUnit.Behave
{
    public interface IBehaviorAction
    {
        string Message { get; }
        void Do();
    }
}