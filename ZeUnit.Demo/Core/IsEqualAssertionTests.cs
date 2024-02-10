namespace ZeUnit.Demo.Core;

public class IsEqualAssertionTests
{
    public Ze ApplyingAnAssertionOnZeCreatesAnEnumerable()
    {
        var result = "test".Is("test");
        return result.IsNotEmpty();
    }

    public Ze SuccessfulResultIsReturnedOnMatch()
    {
        var result = "test".Is("test");

        return result.First().IsType<AssertPassed>();
    }

    public Ze FailedResultIsReturnedOnFailedMatch()
    {
        var result = "test".Is("test-failed");

        return result.First().IsType<AssertFailed>();
    }
}