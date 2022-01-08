namespace ZeUnit.Assertions;

public static class EqualsType
{
    public static ZeResult IsType(this ZeResult result, Type expectedType, object actual)
    {
        var actualType = actual.GetType();
        return result.Assert(expectedType.Equals(actualType)
            ? new Successful($"Type '{actualType.Name}' matched expected result.")
            : new Failed($"Value '{actualType.Name}' didn't match the expected value '{expectedType.Name}'."));
    }

    public static ZeResult IsType<TExpected>(this ZeResult result, object actual)
    {
        return result.IsType(typeof(TExpected), actual);
    }
}
