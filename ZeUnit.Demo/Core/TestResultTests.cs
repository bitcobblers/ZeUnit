namespace ZeUnit.Demo.Core;

public class TestResultTests
{
    public Fact CanCreateATestResult()
    {
        return new Fact(new { }).IsNotNull();
    }
}