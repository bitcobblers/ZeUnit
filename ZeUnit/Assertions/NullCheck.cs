namespace ZeUnit.Assertions;

public static class NullCheck
{
    public static Ze<TType> IsNull<TType>(this TType actual)
    {
        return new Ze<TType>(actual).IsNull();
    }
    public static Ze<TType> IsNull<TType>(this Ze<TType> actual)
    {        
        return (Ze<TType>)actual.Assert(actual.Actual == null
            ? new AssertPassed($"The value is 'null' as expected.")
            : new AssertFailed($"The value is not 'null' but should be."));
    }

    public static Ze<TType> IsNotNull<TType>(this TType actual)
    {
        return new Ze<TType>(actual).IsNotNull();
    }
    public static Ze<TType> IsNotNull<TType>(this Ze<TType> actual)
    {
        return (Ze<TType>)actual.Assert(actual.Actual != null
            ? new AssertPassed($"The value is not 'null' as expected.")
            : new AssertFailed($"The value is 'null' but should not be."));
    }
}
