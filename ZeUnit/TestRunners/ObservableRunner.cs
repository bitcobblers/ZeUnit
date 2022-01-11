namespace ZeUnit.TestRunners;

public abstract class ObservableRunner
{
    public abstract Type SupportType { get; }

    public abstract IObservable<(ZeTest, ZeResult)> Run(ZeTest test, object instance, object[] arguments);
}
