namespace ZeUnit.Assertions;

public static class EqualsValue
{
    public static ZeResult<TType> ShouldBe<TType>(this TType actual, TType expected)
        where TType : IEquatable<TType>
    {
        return new ZeResult<TType>(actual).ShouldBe(expected);        
    }

    public static ZeResult<TType> ShouldBe<TType>(this ZeResult<TType> result, TType expected)
    {
        return (ZeResult<TType>)result.Assert(expected.Equals(result.Value)
            ? new AssertPassed($"Value '{expected}' matched expected results.")
            : new AssertFailed($"Value '{result.Value}' didn't match the expected value '{expected}'."));
    }
}