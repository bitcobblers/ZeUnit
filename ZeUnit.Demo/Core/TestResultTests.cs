namespace ZeUnit.Demo.Core;

[Transient]
public class TestResultTests
{
    public ZeResult CanCreateATestResult()
    {
        return Ze.Is.NotNull(Ze.Is);
    }
}