using System.Reactive.Linq;
using ZeUnit.TestRunners;

namespace ZeUnit;

public class ZeRunner
{
    private readonly List<TestRunner> runners = new List<TestRunner>()
    {
        new ObservableTestRunner(),
        new TaskTestRunner(),
        new EnumerableTestRunner(),
        new ObjectTestRunner(),
    };

    public IEnumerable<Type> SupportedTest => runners.Select(n => n.SupportType);

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