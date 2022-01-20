namespace ZeUnit;

public class AssertError : ZeAssert
{
    public AssertError(Exception ex)
    {
        Ex = ex;
        this.Status = ZeStatus.Failed;
    }

    public Exception Ex { get; }

    public override string Message { get => Ex.Message; }
}
