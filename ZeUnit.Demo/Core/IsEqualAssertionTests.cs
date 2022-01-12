namespace ZeUnit.Demo.Core;

public class IsEqualAssertionTests
{
    public ZeResult ApplyingAnAssertionOnZeResultCreatesAnEnumerable()
    {
        var result = Ze.Is.Equal("test", "test");

        return Ze.Is
            .NotEmpty(result);
    }

    public ZeResult SuccessfulResultIsReturnedOnMatch()
    {
        var result = Ze.Is.Equal("test", "test");

        return Ze.Is
            .Type<AssertPassed>(result.First());
    }

    public ZeResult FailedResultIsReturnedOnFailedMatch()
    {
        var result = Ze.Is.Equal("test", "test-failed");

        return Ze.Is
            .Type<AssertFailed>(result.First());
    }
}