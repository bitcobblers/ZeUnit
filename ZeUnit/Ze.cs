using System.Reactive.Linq;
using ZeUnit.TestRunners;
using System.Linq;

namespace ZeUnit;

public static class Ze
{    
    public static ZeResult Is => new ZeResult();

    public static List<ZeTestRunner> TestRunners = new List<ZeTestRunner>()
    {
        new ObservableTestRunner(),
        new TaskTestRunner(),
        new EnumerableTestRunner(),
        new ObjectTestRunner(),
    };
    
    public static async Task Unit(Func<ZeDiscovery, ZeDiscovery> config, params IZeReporter[] reporters)        
    {        
        var runner = new ZeRunner(TestRunners);
        var discovery = config(new ZeDiscovery(runner.SupportedTest))
            .GroupBy(n=>(n.Class, n.ClassActivator), n=>n);       

        foreach (var classActivation in discovery)
        {
            var @class = classActivation.Key.Item1;
            var composer = classActivation.Key.Item2;

            var lifeCycle = @class
                .GetCustomAttribute<ZeLifeCycleAttribute>() ?? (ZeLifeCycleAttribute)new TransientAttribute();

            var factory = lifeCycle.GetFactory(composer, @class);

            var subject = Observable.Merge(classActivation
                .SelectMany(test => runner.Run(test, factory)))
                .Do(n =>
                {
                    foreach (var reporter in reporters)
                    {
                        reporter.Report(n.Item1, n.Item2);
                    }
                });
            
            await subject.LastAsync();
        }
                               
        foreach (var reporter in reporters)
        {
            reporter.Close();
        }        
    }
}