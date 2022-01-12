namespace ZeUnit.Assertions;

public static class EqualsType
{
    public static ZeResult Type(this ZeResult result, Type expectedType, object actual)
    {
        var actualType = actual.GetType();
        return result.Assert(expectedType.Equals(actualType)
            ? new AssertPassed($"Type '{actualType.Name}' matched expected result.")
            : new AssertFailed($"Value '{actualType.Name}' didn't match the expected value '{expectedType.Name}'."));
    }

    public static ZeResult Type<TExpected>(this ZeResult result, object actual)
    {
        return result.Type(typeof(TExpected), actual);
    }
}
