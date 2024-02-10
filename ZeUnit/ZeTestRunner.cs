namespace ZeUnit;

public abstract class ZeTestRunner
{
    public abstract Type SupportType { get; }

    public abstract IObservable<(ZeTest, Ze)> Run(ZeTest test, ZeClassInstanceFactory factory, object[] arguments);
}
