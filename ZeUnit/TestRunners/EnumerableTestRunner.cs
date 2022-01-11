using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit.TestRunners;

public class EnumerableTestRunner : TestRunner<IEnumerable<ZeResult>>
{
    public override IObservable<(ZeTest, ZeResult)> Run(ZeTest test, object instance, object[] arguments)
    {
        var subject = new ReplaySubject<(ZeTest, ZeResult)>();
        foreach (var result in (IEnumerable<ZeResult>)test.Method.Invoke(instance, arguments.Any() ? arguments : null))
        {
            subject.OnNext((test, result));
        }
        subject.OnCompleted();
        return subject;
    }
}
