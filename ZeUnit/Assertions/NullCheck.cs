namespace ZeUnit.Assertions;

public static class NullCheck
{
    public static Fact<TType> IsNull<TType>(this TType actual)
    {
        return new Fact<TType>(actual).IsNull();
    }
    public static Fact<TType> IsNull<TType>(this Fact<TType> actual)
    {        
        return (Fact<TType>)actual.Assert(actual.Actual == null
            ? new AssertPassed($"The value is 'null' as expected.")
            : new AssertFailed($"The value is not 'null' but should be."));
    }

    public static Fact<TType> IsNotNull<TType>(this TType actual)
    {
        return new Fact<TType>(actual).IsNotNull();
    }
    public static Fact<TType> IsNotNull<TType>(this Fact<TType> actual)
    {
        return (Fact<TType>)actual.Assert(actual.Actual != null
            ? new AssertPassed($"The value is not 'null' as expected.")
            : new AssertFailed($"The value is 'null' but should not be."));
    }
}
