namespace ZeUnit.Assertions;

public static class Is
{
    public static Fact Skipped(string message = "Skipped during execution.") => new Fact(null!).Assert(new AssertSkipped(message));
}

public static class Is<TException>
    where TException : Exception
{
    public static Fact Thrown<TArg, TType>(Func<TArg, TType> fn, TArg arg)
    {
        return Thrown(() => { _ = fn(arg); });
    }

    public static Fact Thrown<TArg1, TArg2, TType>(Func<TArg1, TArg2, TType> fn, TArg1 arg1, TArg2 arg2)
    {
        return Thrown(() => { _ = fn(arg1, arg2); });
    }

    public static Fact Thrown<TArg1, TArg2, TArg3, TType>(Func<TArg1, TArg2, TArg3, TType> fn, TArg1 arg1, TArg2 arg2, TArg3 arg3)
    {
        return Thrown(() => { _ = fn(arg1, arg2, arg3); });
    }

    public static Fact Thrown<TArg1, TArg2, TArg3, TArg4, TType>(Func<TArg1, TArg2, TArg3, TArg4, TType> fn, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
    {
        return Thrown(() => { _ = fn(arg1, arg2, arg3, arg4); });
    }

    public static Fact Thrown<TType>(Func<TType> fn)
    {
        return Thrown(() => { _ = fn(); });
    }

    public static Fact Thrown(Action action)
    {
        var errorType = typeof(TException);
        try
        {
            action();
            return new Fact(null!)
                .Assert(new AssertFailed($"Expected {errorType} but no error was thrown."));
        }
        catch (Exception ex)
        {
            var type = ex.GetType();
            if (type.IsAssignableTo(errorType))
            {
                return new Fact(ex)
                    .Assert(new AssertPassed($"Expected error {type} was thrown."));
            }

            return new Fact(null!)
                .Assert(new AssertFailed($"Expected {errorType} but error of type {type} was thrown."))
                .Assert(new AssertError(ex));

        }
    }
}