using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit.TestRunners;

public class EnumerableTestRunner : ZeTestRunner<IEnumerable<Ze>>
{
    public override IObservable<(ZeTest, Ze)> Run(ZeTest test, ZeClassInstanceFactory factory, object[] arguments)
    {
        var instance = factory.Create();
        var subject = new AsyncSubject<(ZeTest, Ze)>();
        foreach (var result in (IEnumerable<Ze>)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!)
        {
            subject.OnNext((test, result));
        }
        subject.OnCompleted();
        return subject;
    }
}
