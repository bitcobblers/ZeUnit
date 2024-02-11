namespace ZeUnit.Assertions;

public static class TrueFalseCondition
{
    public static Fact<bool> True(this bool result, string? message = null)
    {
        return new Fact<bool>(result).True(message);
    }

    public static Fact<bool> True(this Fact<bool> result, string? message = null)
    {
        return (Fact<bool>)result.Assert(result.Value
            ? new AssertPassed(message ?? $"Condition satisfied.")
            : new AssertFailed(message ?? $"Expected 'true' but got 'false'"));
    }

    public static Fact<bool> False(this bool result)
    {
        return new Fact<bool>(result).False();
    }

    public static Fact<bool> False(this Fact<bool> result)
    {
        return (Fact<bool>)result.Assert(result.Value
            ? new AssertPassed($"Condition satisfied.")
            : new AssertFailed($"Expected 'false' but got 'true'"));
    }
}
