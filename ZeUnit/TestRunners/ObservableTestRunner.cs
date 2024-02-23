using System.Reactive.Linq;

namespace ZeUnit.TestRunners;

public class ObservableTestRunner : ZeTestRunner<IObservable<Fact>>
{
    public override IObservable<(ZeTest, Fact)> Run(ZeTest test, IZeClassFactory factory, object[] arguments)
    {
        var instance = factory.Get();
        return ((IObservable<Fact>)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!)
            .Select(n => (test, n));
    }
}
