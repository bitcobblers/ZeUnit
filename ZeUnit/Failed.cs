namespace ZeUnit;

public class Failed : ZeAssertion
{
    public Failed(string message)
    {
        this.Status = ZeStatus.Failed;
        this.Message = message;
    }
}