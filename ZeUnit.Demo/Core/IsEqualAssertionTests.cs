namespace ZeUnit.Demo.Core;

public class IsEqualAssertionTests
{
    public Fact ApplyingAnAssertionOnZeCreatesAnEnumerable()
    {
        var result = "test".Is("test");
        return result.IsNotEmpty();
    }

    public Fact SuccessfulResultIsReturnedOnMatch()
    {
        var result = "test".Is("test");

        return result.First().IsType<AssertPassed>();
    }

    public Fact FailedResultIsReturnedOnFailedMatch()
    {
        var result = "test".Is("test-failed");

        return result.First().IsType<AssertFailed>();
    }
}