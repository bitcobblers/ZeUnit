namespace ZeUnit.Assertions;

public static class EqualsValue
{    
    public static ZeResult Equal<TType>(this ZeResult result, TType expected, TType actual)
        where TType : IEquatable<TType>
    {
        return result.Assert(expected.Equals(actual)
            ? new Successful($"Value '{expected}' matched expected results.")
            : new Failed($"Value '{actual}' didn't match the expected value '{expected}'."));
    }
}