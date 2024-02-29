namespace ZeUnit.Assertions;

public static class ThrowsException
{
    public delegate void ActionUnderTest();

    public static class Throws<TException>
        where TException : Exception
    {
        public static Fact On<TType>(Func<TType> fn)
        {
            return On(() => _ = fn());
        }
        
        public static Fact On(Action action)               
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
                if (type == errorType)
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
}
