namespace ZeUnit.Assertions;

public static class NullCheck
{
    public static ZeResult<TType> IsNull<TType>(this TType actual)
    {
        return new ZeResult<TType>(actual).IsNull();
    }
    public static ZeResult<TType> IsNull<TType>(this ZeResult<TType> actual)
    {        
        return (ZeResult<TType>)actual.Assert(actual.Actual == null
            ? new AssertPassed($"The value is 'null' as expected.")
            : new AssertFailed($"The value is not 'null' but should be."));
    }

    public static ZeResult<TType> IsNotNull<TType>(this TType actual)
    {
        return new ZeResult<TType>(actual).IsNotNull();
    }
    public static ZeResult<TType> IsNotNull<TType>(this ZeResult<TType> actual)
    {
        return (ZeResult<TType>)actual.Assert(actual.Actual != null
            ? new AssertPassed($"The value is not 'null' as expected.")
            : new AssertFailed($"The value is 'null' but should not be."));
    }
}
