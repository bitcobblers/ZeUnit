using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ZeUnit;

public class ZeRunner
{
    private readonly List<ObservableRunner> runners = new List<ObservableRunner>()
    {
        new ObservableResultRunner(),
        new TaskResultRunner(),
        new EnumerableResultRunner(),
        new SingleResultRunner(),
    };
    
    public IEnumerable<IObservable<(ZeTest, ZeResult)>> Run(ZeTest test)
    {                       
        var instance = test.ClassActivator.Get(test.Class);               
        foreach (var arguments in test.MethdoActivator.Get(test.Method))
        {            
            var runner = runners.First(n => n.SupportType == test.Method.ReturnType);
            yield return runner.Run(test, instance, arguments);            
        }               
    }
}