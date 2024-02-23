using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace ZeUnit.TestRunners;

public class TaskTestRunner : ZeTestRunner<Task<Fact>>
{
    public override IObservable<(ZeTest, Fact)> Run(ZeTest test, IZeClassFactory factory, object[] arguments)
    {
        var instance = factory.Get();
        return ((Task<Fact>)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!)
            .ToObservable()
            .Select(evnt => (test, evnt));
    }
}
