namespace ZeUnit.Assertions;

public static class TrueFalseCondition
{
    public static ZeResult<bool> True(this bool result)
    {
        return new ZeResult<bool>(result).True();
    }

    public static ZeResult<bool> True(this ZeResult<bool> result)
    {
        return (ZeResult<bool>)result.Assert(result.Value
            ? new AssertPassed($"Condition satisfied.")
            : new AssertFailed($"Expected 'true' but got 'false'"));
    }

    public static ZeResult<bool> False(this bool result)
    {
        return new ZeResult<bool>(result).False();
    }

    public static ZeResult<bool> False(this ZeResult<bool> result)
    {
        return (ZeResult<bool>)result.Assert(result.Value
            ? new AssertPassed($"Condition satisfied.")
            : new AssertFailed($"Expected 'false' but got 'true'"));
    }
}
