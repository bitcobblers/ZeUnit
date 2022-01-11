namespace ZeUnit.Assertions;

public static class NullCheck
{
    public static ZeResult Null(this ZeResult result, object actual)
    {        
        return result.Assert(actual == null
            ? new Successful($"The value is 'null' as expected.")
            : new Failed($"The value is not 'null' but should be."));
    }

    public static ZeResult NotNull(this ZeResult result, object actual)
    {
        return result.Assert(actual != null
            ? new Successful($"The value is not 'null' as expected.")
            : new Failed($"The value is 'null' but should not be."));
    }
}
