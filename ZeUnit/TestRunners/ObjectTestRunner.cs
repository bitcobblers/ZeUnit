using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit.TestRunners;

public class ObjectTestRunner : ZeTestRunner<ZeResult>
{
    public override IObservable<(ZeTest, ZeResult)> Run(ZeTest test, object instance, object[] arguments)
    {
        var subject = new ReplaySubject<(ZeTest, ZeResult)>();
        subject.OnNext((test, (ZeResult)test.Method.Invoke(instance, arguments.Any() ? arguments : null)));
        subject.OnCompleted();
        return subject;
    }
}
