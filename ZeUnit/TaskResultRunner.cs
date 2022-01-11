using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace ZeUnit;

public class TaskResultRunner : ObservableRunner<Task<ZeResult>>
{
    public override void Run(IObserver<(ZeTest,ZeResult)> subject, ZeTest test, object instance, object[] arguments)
    {        
        ((Task<ZeResult>)test.Method.Invoke(instance, arguments.Any() ? arguments : null))
            .ToObservable()
            .Subscribe(evnt => subject.OnNext((test, evnt)));
    }
}
