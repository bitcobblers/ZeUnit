namespace ZeUnit;

using System.Reactive.Linq;

public static class ZeGlobal
{        
    public static IObservable<(ZeTest, Ze)> Unit(ZeBuilder builder)   
    {
        var classRuns = new List<IObservable<(ZeTest, Ze)>>();
        var reporter = builder.GetReporter();
        var discovery = builder.GetDiscovery()
            .GroupBy(test => (test.Class, test.ClassActivator), test => test);
        
        foreach (var classActivation in discovery)
        {
            var (@class, composer) = classActivation.Key;            
            var lifeCycle = @class!
                .GetCustomAttribute<ZeLifeCycleAttribute>() ?? (ZeLifeCycleAttribute)new TransientAttribute();
            try
            {
                var factory = lifeCycle.GetFactory(composer!, @class!);

                classRuns.AddRange(classActivation
                    .Select(test => new ZeRunner(builder.Runners()).Run(test, factory)));
            }
            catch (Exception ex)
            {
                classRuns.AddRange(classActivation.Select(test => new ZeTestException(test, ex)));
            }
        }

        return Observable.Merge(classRuns)
            .Do(reporter);

    }
}