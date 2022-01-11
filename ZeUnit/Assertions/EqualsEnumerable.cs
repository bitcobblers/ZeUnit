namespace ZeUnit.Assertions;

public static class EqualsEnumerable
{
    public static ZeResult IsNotEmpty<TType>(this ZeResult result, IEnumerable<TType> enumerable)
    {        
        return result.Assert(enumerable.Any()
            ? new Successful($"Enumerable contains items.")
            : new Failed($"Enumerable expected to have elements, but none were found."));
    }
}
