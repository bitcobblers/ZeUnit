namespace ZeUnit.Assertions;

public static class ThrowsException
{
    public static Fact Throws<TError>(this Action action)
        where TError : Exception
    {
        try
        {
            action();
            return new Fact<TError>(null!)
                .Assert(new AssertFailed($"Expected {typeof(TError)} but no error was thrown."));
        }
        catch (Exception ex)
        {
            var type = ex.GetType();
            if (type == typeof(TError))
            {
                return new Fact<TError>((TError)ex)
                    .Assert(new AssertPassed($"Expected error {type} was thrown."));
            }

            return new Fact<TError>(null!)                
                .Assert(new AssertFailed($"Expected {typeof(TError)} but error of type {type} was thrown."))
                .Assert(new AssertError(ex));

        }        
    }

}
