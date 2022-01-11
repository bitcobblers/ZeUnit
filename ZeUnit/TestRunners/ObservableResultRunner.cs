using System.Reactive.Linq;

namespace ZeUnit.TestRunners;

public class ObservableResultRunner : ObservableRunner<IObservable<ZeResult>>
{
    public override IObservable<(ZeTest, ZeResult)> Run(ZeTest test, object instance, object[] arguments)
    {
        return ((IObservable<ZeResult>)test.Method.Invoke(instance, arguments.Any() ? arguments : null))
            .Select(n => (test, n));
    }
}
