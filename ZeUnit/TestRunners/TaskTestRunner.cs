using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace ZeUnit.TestRunners;

public class TaskTestRunner : ZeTestRunner<Task<ZeResult>>
{
    public override IObservable<(ZeTest, ZeResult)> Run(ZeTest test, object instance, object[] arguments)
    {
        return ((Task<ZeResult>)test.Method.Invoke(instance, arguments.Any() ? arguments : null))
            .ToObservable()
            .Select(evnt => (test, evnt));
    }
}
