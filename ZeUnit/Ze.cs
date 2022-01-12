using System.Reactive.Linq;
using ZeUnit.TestRunners;

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
    
    public static async Task<int> Unit(Func<ZeDiscovery, ZeDiscovery> config, params IZeReporter[] reporters)        
    {        
        var runner = new ZeRunner(TestRunners);
        var discovery = config(new ZeDiscovery(runner.SupportedTest));
        var failCount = 0;        

        var subject = Observable.Merge(discovery
            .SelectMany(test => runner.Run(test)))
            .Do(n =>
            {
                foreach (var reporter in reporters)
                {
                    reporter.Report(n.Item1, n.Item2);
                }                
            });
                
        await subject.LastAsync();
        foreach (var reporter in reporters)
        {
            reporter.Close();
        }

        return failCount;
    }
}