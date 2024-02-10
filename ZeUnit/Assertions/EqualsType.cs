namespace ZeUnit.Assertions;

public static class EqualsType
{
    public static Ze IsType<TExpected>(this Ze actual)
    {
        var expectedType = typeof(TExpected);
        var actualType = actual.Actual?.GetType() ?? typeof(object);
        return actual.Assert(expectedType.Equals(actualType)
            ? new AssertPassed($"Type '{actualType.Name}' matched expected result.")
            : new AssertFailed($"Value '{actualType.Name}' didn't match the expected value '{expectedType.Name}'."));
    }

    public static Ze IsType<TExpected>(this object actual)
    {
        return new Ze(actual).IsType<TExpected>();
    }
}
