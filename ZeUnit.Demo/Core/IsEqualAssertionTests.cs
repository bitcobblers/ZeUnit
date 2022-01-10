namespace ZeUnit.Demo.Core;

public class IsEqualAssertionTests
{
    public ZeResult ApplyingAnAssertionOnZeResultCreatesAnEnumerable()
    {
        var result = Ze.Assert().IsEqual("test", "test");

        return Ze.Assert()
            .IsNotEmpty(result);
    }

    public ZeResult SuccessfulResultIsReturnedOnMatch()
    {
        var result = Ze.Assert().IsEqual("test", "test");

        return Ze.Assert()
            .IsType<Successful>(result.First());
    }

    public ZeResult FailedResultIsReturnedOnFailedMatch()
    {
        var result = Ze.Assert().IsEqual("test", "test-failed");

        return Ze.Assert()
            .IsType<Failed>(result.First());
    }
}