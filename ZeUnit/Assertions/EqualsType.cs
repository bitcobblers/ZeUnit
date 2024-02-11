namespace ZeUnit.Assertions;

public static class EqualsType
{
    public static Fact IsType<TExpected>(this Fact actual)
    {
        var expectedType = typeof(TExpected);
        var actualType = actual.Actual?.GetType() ?? typeof(object);
        return actual.Assert(expectedType.Equals(actualType)
            ? new AssertPassed($"Type '{actualType.Name}' matched expected result.")
            : new AssertFailed($"Value '{actualType.Name}' didn't match the expected value '{expectedType.Name}'."));
    }

    public static Fact IsType<TExpected>(this object actual)
    {
        return new Fact(actual).IsType<TExpected>();
    }
}
