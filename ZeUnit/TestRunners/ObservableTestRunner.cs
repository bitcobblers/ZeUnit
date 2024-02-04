using System.Reactive.Linq;

namespace ZeUnit.TestRunners;

public class ObservableTestRunner : ZeTestRunner<IObservable<ZeResult>>
{
    public override IObservable<(ZeTest, ZeResult)> Run(ZeTest test, ZeClassInstanceFactory factory, object[] arguments)
    {
        var instance = factory.Create();
        return ((IObservable<ZeResult>)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!)
            .Select(n => (test, n));
    }
}
