namespace ZeUnit.Demo.Core;

public class IsEqualAssertionTests
{
    public ZeResult ApplyingAnAssertionOnZeResultCreatesAnEnumerable()
    {
        var result = "test".ShouldBe("test");
        return result.NotEmpty();
    }

    public ZeResult SuccessfulResultIsReturnedOnMatch()
    {
        var result = "test".ShouldBe("test");

        return result.First().Type<AssertPassed>();
    }

    public ZeResult FailedResultIsReturnedOnFailedMatch()
    {
        var result = "test".ShouldBe("test-failed");

        return result.First().Type<AssertFailed>();
    }
}