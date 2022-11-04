using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit.TestRunners;

public class ObjectTestRunner : ZeTestRunner<ZeResult>
{
    public override IObservable<(ZeTest, ZeResult)> Run(ZeTest test, ZeClassInstanceFactory factory, object[] arguments)    
    {
        var instance = factory.Create();
        var subject = new AsyncSubject<(ZeTest, ZeResult)>();
        subject.OnNext((test, (ZeResult)test.Method.Invoke(instance, arguments.Any() ? arguments : null)));
        subject.OnCompleted();
        return subject;
    }
}
