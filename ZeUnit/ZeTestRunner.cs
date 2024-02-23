namespace ZeUnit;

public abstract class ZeTestRunner
{
    public abstract Type SupportType { get; }

    public abstract IObservable<(ZeTest, Fact)> Run(ZeTest test, IZeClassFactory factory, object[] arguments);
}
