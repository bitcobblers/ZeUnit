using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace ZeUnit.TestRunners;

public class TaskTestRunner : ZeTestRunner<Task<Fact>>
{
    public override IObservable<(ZeTest, Fact)> Run(ZeTest test, ZeClassInstanceFactory factory, object[] arguments)
    {
        var instance = factory.Create();
        return ((Task<Fact>)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!)
            .ToObservable()
            .Select(evnt => (test, evnt));
    }
}
