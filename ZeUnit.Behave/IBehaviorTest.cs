namespace ZeUnit.Behave
{
    public interface IBehaviorTest 
    {
        string Message { get; }

        ZeResult Do();
    }
}