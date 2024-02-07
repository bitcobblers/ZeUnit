namespace ZeUnit.Demo.Core;

public class IsEqualAssertionTests
{
    public ZeResult ApplyingAnAssertionOnZeResultCreatesAnEnumerable()
    {
        var result = "test".Is("test");
        return result.IsNotEmpty();
    }

    public ZeResult SuccessfulResultIsReturnedOnMatch()
    {
        var result = "test".Is("test");

        return result.First().IsType<AssertPassed>();
    }

    public ZeResult FailedResultIsReturnedOnFailedMatch()
    {
        var result = "test".Is("test-failed");

        return result.First().IsType<AssertFailed>();
    }
}