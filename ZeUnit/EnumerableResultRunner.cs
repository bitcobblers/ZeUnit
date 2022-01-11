using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit;

public class EnumerableResultRunner : ObservableRunner<IEnumerable<ZeResult>>
{
    public override void Run(IObserver<(ZeTest, ZeResult)> subject, ZeTest test, object instance, object[] arguments)
    {        
        foreach (var result in (IEnumerable<ZeResult>)test.Method.Invoke(instance, arguments.Any() ? arguments : null))
        {
            subject.OnNext((test, result));
        }     
    }
}
