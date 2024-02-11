namespace ZeUnit.Assertions;

public static class EqualsEnumerable
{
    public static Fact IsNotEmpty<TType>(this IEnumerable<TType> enumerable)        
    {        
        return new Fact<IEnumerable<TType>>(enumerable).Assert(enumerable.Any()
            ? new AssertPassed($"Enumerable contains items.")
            : new AssertFailed($"Enumerable expected to have elements, but none were found."));
    }
}
