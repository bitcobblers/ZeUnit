namespace ZeUnit;

public abstract class ZeTestRunner
{
    public abstract Type SupportType { get; }

    public abstract IObservable<(ZeTest, ZeResult)> Run(ZeTest test, object instance, object[] arguments);
}
