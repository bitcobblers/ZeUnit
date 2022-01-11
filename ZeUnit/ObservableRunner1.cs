namespace ZeUnit;

public abstract class ObservableRunner 
{
    public abstract Type SupportType { get; }

    public abstract void Run(IObserver<(ZeTest, ZeResult)> observer, ZeTest test, object instance, object[] arguments);
}
