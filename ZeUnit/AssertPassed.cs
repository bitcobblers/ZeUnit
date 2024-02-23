namespace ZeUnit;

public class AssertPassed : ZeAssert
{
    public AssertPassed(string message)
    {
        this.Status = ZeStatus.Passed;
        this.Message = message;
    }
}

public class AssertSkipped : ZeAssert
{
    public AssertSkipped(string message)
    {
        this.Status = ZeStatus.Passed;
        this.Message = message;
    }
}