namespace ZeUnit.Demo.Core;

[Transient]
public class TestResultTests
{
    public ZeResult CanCreateATestResult()
    {
        return new ZeResult(new { }).NotNull();
    }
}