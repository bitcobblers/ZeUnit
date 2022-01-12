namespace ZeUnit.Assertions;

public static class EqualsEnumerable
{
    public static ZeResult NotEmpty<TType>(this ZeResult result, IEnumerable<TType> enumerable)
    {        
        return result.Assert(enumerable.Any()
            ? new AssertPassed($"Enumerable contains items.")
            : new AssertFailed($"Enumerable expected to have elements, but none were found."));
    }
}
