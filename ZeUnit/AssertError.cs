namespace ZeUnit;

public class AssertError : ZeAssert
{
    public AssertError(Exception ex)
    {
        Ex = ex;
        this.Message = ex.Message;
        this.Status = ZeStatus.Failed;
    }

    public Exception Ex { get; }    
}
