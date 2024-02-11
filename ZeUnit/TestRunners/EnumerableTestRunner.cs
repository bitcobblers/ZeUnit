using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit.TestRunners;

public class EnumerableTestRunner : ZeTestRunner<IEnumerable<Fact>>
{
    public override IObservable<(ZeTest, Fact)> Run(ZeTest test, ZeClassInstanceFactory factory, object[] arguments)
    {
        var instance = factory.Create();
        var subject = new AsyncSubject<(ZeTest, Fact)>();
        foreach (var result in (IEnumerable<Fact>)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!)
        {
            subject.OnNext((test, result));
        }
        subject.OnCompleted();
        return subject;
    }
}
