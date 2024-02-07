namespace ZeUnit.Assertions;

public static class EqualsEnumerable
{
    public static ZeResult IsNotEmpty<TType>(this IEnumerable<TType> enumerable)        
    {        
        return new ZeResult<IEnumerable<TType>>(enumerable).Assert(enumerable.Any()
            ? new AssertPassed($"Enumerable contains items.")
            : new AssertFailed($"Enumerable expected to have elements, but none were found."));
    }
}
