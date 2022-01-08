namespace ZeUnit;

public class Successful : ZeAssertion
{
    public Successful(string message)
    {
        this.Status = ZeStatus.Passed;
        this.Message = message;
    }
}