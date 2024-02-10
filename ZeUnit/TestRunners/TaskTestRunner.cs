using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace ZeUnit.TestRunners;

public class TaskTestRunner : ZeTestRunner<Task<Ze>>
{
    public override IObservable<(ZeTest, Ze)> Run(ZeTest test, ZeClassInstanceFactory factory, object[] arguments)
    {
        var instance = factory.Create();
        return ((Task<Ze>)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!)
            .ToObservable()
            .Select(evnt => (test, evnt));
    }
}
