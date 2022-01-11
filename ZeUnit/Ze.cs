using System.Reactive.Linq;

namespace ZeUnit;

public static class Ze
{
    public static ZeResult Assert()
    {
        return new ZeResult();
    }       

    public static async Task<int> Unit(Func<ZeDiscovery, ZeDiscovery> config, params IZeReporter[] reporters)        
    {        
        var runner = new ZeRunner();
        var discovery = config(new ZeDiscovery());
        var failCount = 0;        

        var subject = Observable.Merge(discovery
            .SelectMany(test => runner.Run(test)))
            .Do(n =>
            {
                if (n.Item2.State == ZeStatus.Failed)
                {
                    failCount++;
                }
                foreach (var reporter in reporters)
                {
                    reporter.Report(n.Item1, n.Item2);
                }                
            });
                
        await subject.LastAsync();
        return failCount;
    }
}