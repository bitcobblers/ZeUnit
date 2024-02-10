namespace ZeUnit.Assertions;

public static class TrueFalseCondition
{
    public static Ze<bool> True(this bool result, string? message = null)
    {
        return new Ze<bool>(result).True(message);
    }

    public static Ze<bool> True(this Ze<bool> result, string? message = null)
    {
        return (Ze<bool>)result.Assert(result.Value
            ? new AssertPassed(message ?? $"Condition satisfied.")
            : new AssertFailed(message ?? $"Expected 'true' but got 'false'"));
    }

    public static Ze<bool> False(this bool result)
    {
        return new Ze<bool>(result).False();
    }

    public static Ze<bool> False(this Ze<bool> result)
    {
        return (Ze<bool>)result.Assert(result.Value
            ? new AssertPassed($"Condition satisfied.")
            : new AssertFailed($"Expected 'false' but got 'true'"));
    }
}
