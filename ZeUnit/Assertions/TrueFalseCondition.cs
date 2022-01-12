namespace ZeUnit.Assertions;

public static class TrueFalseCondition
{
    public static ZeResult True(this ZeResult result, bool condition)
    {
        return result.Assert(condition
            ? new AssertPassed($"Condition satisfied.")
            : new AssertFailed($"Expected 'true' but got 'false'"));
    }

    public static ZeResult False(this ZeResult result, bool condition)
    {
        return result.Assert(!condition
            ? new AssertPassed($"Condition satisfied.")
            : new AssertFailed($"Expected 'false' but got 'true'"));
    }
}
