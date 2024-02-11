namespace ZeUnit.Demo.Core;

[Transient]
public class TestResultTests
{
    public Fact CanCreateATestResult()
    {
        return new Fact(new { }).IsNotNull();
    }
}