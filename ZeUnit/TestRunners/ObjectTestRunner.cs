using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit.TestRunners;

public class ObjectTestRunner : ZeTestRunner<Ze>
{
    public override IObservable<(ZeTest, Ze)> Run(ZeTest test, ZeClassInstanceFactory factory, object[] arguments)    
    {
        var instance = factory.Create();
        var subject = new AsyncSubject<(ZeTest, Ze)>();
        subject.OnNext((test, (Ze)test.Method!.Invoke(instance, arguments.Any() ? arguments : null)!));
        subject.OnCompleted();
        return subject;
    }
}
