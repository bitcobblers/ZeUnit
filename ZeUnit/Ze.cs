using System.Reactive.Linq;
using ZeUnit.TestRunners;
using System.Linq;
using System.Reactive;

namespace ZeUnit;

public static class Ze
{    
    public static ZeResult Is => new ZeResult();
    
    public static IEnumerable<TType> Each<TType>(this IEnumerable<TType> enumerable, Action<TType> action)
    {
        foreach (var item in enumerable)
        {
            action(item);
        }
        return enumerable;
    }

    public static async Task Unit(Func<ZeDiscovery, ZeDiscovery> config, ZeTestRunnerDiscovery runnerDiscovery, params IZeReporter[] reporters)        
    {                        
        var runner = new ZeRunner(runnerDiscovery.Runners());
        var discovery = config(new ZeDiscovery(runnerDiscovery.SupportedTypes()))
            .GroupBy(n=>(n.Class, n.ClassActivator), n=>n);

        var report = Observer.Create<(ZeTest, ZeResult)>(
            n => _ = reporters.Each(r => r.OnNext(n)),
            e => _ = reporters.Each(r => r.OnError(e)),
            () => _ = reporters.Each(r => r.OnCompleted())
        );

        var classRuns = new List<IObservable<(ZeTest, ZeResult)>>();
        foreach (var classActivation in discovery)
        {
            var @class = classActivation.Key.Item1;
            var composer = classActivation.Key.Item2;

            var lifeCycle = @class
                .GetCustomAttribute<ZeLifeCycleAttribute>() ?? (ZeLifeCycleAttribute)new TransientAttribute();

            var factory = lifeCycle.GetFactory(composer, @class);

            classRuns.Add(Observable.Merge(classActivation
                .SelectMany(test => runner.Run(test, factory)))
                .Do(n => report.OnNext(n)));            
        }

        await Observable.Merge(classRuns).LastAsync();
        report.OnCompleted();
    }
}