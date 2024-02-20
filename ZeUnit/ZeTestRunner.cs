namespace ZeUnit;

public abstract class ZeTestRunner
{
    public abstract Type SupportType { get; }

    public abstract IObservable<(ZeTest, Fact)> Run(ZeTest test, IZeLifeCycleFactory factory, object[] arguments);
}
