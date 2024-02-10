using System.Reactive.Linq;

namespace ZeUnit.TestRunners;

public class ObservableTestRunner : ZeTestRunner<IObservable<Ze>>
{
    public override IObservable<(ZeTest, Ze)> Run(ZeTest test, ZeClassInstanceFactory factory, object[] arguments)
    {
        var instance = factory.Create();
        return ((IObservable<Ze>)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!)
            .Select(n => (test, n));
    }
}
