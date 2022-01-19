using System.Reactive.Linq;
using ZeUnit.TestRunners;

namespace ZeUnit;

public class ZeRunner
{
    private readonly IEnumerable<ZeTestRunner> runners;    

    public ZeRunner(IEnumerable<ZeTestRunner> testRunners)
    {
        this.runners = testRunners;
    }

    public IEnumerable<IObservable<(ZeTest, ZeResult)>> Run(ZeTest test, ZeClassInstanceFactory factory)
    {                               
        foreach (var arguments in test.MethdoActivator.Get(test.Method))
        {            
            var instance = factory.Create();
            var runner = runners.First(n => n.SupportType == test.Method.ReturnType);
            yield return runner.Run(test, instance, arguments);            
        }               
    }
}