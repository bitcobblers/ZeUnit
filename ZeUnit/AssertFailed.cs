namespace ZeUnit;

public class AssertFailed : ZeAssert
{
    public AssertFailed(string message)
    {
        this.Status = ZeStatus.Failed;
        this.Message = message;
    }
}