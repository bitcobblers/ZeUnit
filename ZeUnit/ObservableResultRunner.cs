using System.Reactive.Linq;

namespace ZeUnit;

public class ObservableResultRunner : ObservableRunner<IObservable<ZeResult>>
{
    public override void Run(IObserver<(ZeTest, ZeResult)> subject, ZeTest test, object instance, object[] arguments)
    {
        ((IObservable<ZeResult>)test.Method.Invoke(instance, arguments.Any() ? arguments : null))
            .Subscribe(evnt => subject.OnNext((test, evnt)));
    }
}
