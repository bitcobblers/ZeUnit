namespace ZeUnit.Tests;

public class IsEqualAssertionTests 
{ 
    [Fact]
    public void ApplyingAnAssertionOnZeResultCreatesAnEnumerable()
    {
        var result = Ze.Assert().IsEqual("test", "test");
        Assert.NotEmpty(result);
    }

    [Fact]
    public void SuccessfulResultIsReturnedOnMatch()
    {
        var result = Ze.Assert().IsEqual("test", "test");
        Assert.IsType<Successful>(result.First());
    }

    [Fact]
    public void FailedResultIsReturnedOnFailedMatch()
    {
        var result = Ze.Assert().IsEqual("test", "test-failed");
        Assert.IsType<Failed>(result.First());
    }
}