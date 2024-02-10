namespace ZeUnit.Assertions;

public static class EqualsValue
{
    public static Ze<TType> Is<TType>(this TType actual, TType expected)
        where TType : IEquatable<TType>
    {
        return new Ze<TType>(actual).Is(expected);        
    }

    public static Ze<TType> Is<TType>(this Ze<TType> result, TType expected)
    {
        return (Ze<TType>)result.Assert(expected.Equals(result.Value)
            ? new AssertPassed($"Value '{expected}' matched expected results.")
            : new AssertFailed($"Value '{result.Value}' didn't match the expected value '{expected}'."));
    }
}