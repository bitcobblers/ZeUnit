namespace ZeUnit.Assertions;

public static partial class ThrowsException
{
    public static class Throws<TException>
        where TException : Exception
    {
        public static Fact On<TArg, TType>(Func<TArg, TType> fn, TArg arg)
        {            
            return On(() => _ = fn(arg));
        }

        public static Fact On<TArg1, TArg2, TType>(Func<TArg1, TArg2, TType> fn, TArg1 arg1, TArg2 arg2)
        {
            return On(() => _ = fn(arg1, arg2));
        }

        public static Fact On<TArg1, TArg2, TArg3, TType>(Func<TArg1, TArg2, TArg3, TType> fn, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            return On(() => _ = fn(arg1, arg2, arg3));
        }

        public static Fact On<TArg1, TArg2, TArg3, TArg4, TType>(Func<TArg1, TArg2, TArg3, TArg4, TType> fn, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            return On(() => _ = fn(arg1, arg2, arg3, arg4));
        }

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
