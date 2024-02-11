namespace ZeUnit.Assertions;

public static class EqualsValue
{
    public static Fact<TType> Is<TType>(this TType actual, TType expected)
        where TType : IEquatable<TType>
    {
        return new Fact<TType>(actual).Is(expected);        
    }

    public static Fact<TType> Is<TType>(this Fact<TType> result, TType expected)
    {
        return (Fact<TType>)result.Assert(expected.Equals(result.Value)
            ? new AssertPassed($"Value '{expected}' matched expected results.")
            : new AssertFailed($"Value '{result.Value}' didn't match the expected value '{expected}'."));
    }
}