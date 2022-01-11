using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit;

public class SingleResultRunner : ObservableRunner<ZeResult>
{
    public override void Run(IObserver<(ZeTest, ZeResult)> subject, ZeTest test, object instance, object[] arguments)
    {        
        subject.OnNext((test, (ZeResult)test.Method.Invoke(instance, arguments.Any() ? arguments : null)));
    }
}
