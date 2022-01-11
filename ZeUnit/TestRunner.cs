namespace ZeUnit;

public abstract class TestRunner
{
    public abstract Type SupportType { get; }

    public abstract IObservable<(ZeTest, ZeResult)> Run(ZeTest test, object instance, object[] arguments);
}
