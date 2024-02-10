namespace ZeUnit.Demo.Core;

[Transient]
public class TestResultTests
{
    public Ze CanCreateATestResult()
    {
        return new Ze(new { }).IsNotNull();
    }
}