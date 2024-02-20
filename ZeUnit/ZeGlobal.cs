namespace ZeUnit;

using System.Reactive.Linq;

public static class ZeGlobal
{        
    public static IObservable<(ZeTest, Fact)> Unit(ZeBuilder builder)   
    {
        var classRuns = new List<IObservable<(ZeTest, Fact)>>();
        var reporter = builder.GetReporter();
        var discovery = builder.GetDiscovery()
            .GroupBy(test => (test.Class, test.ClassActivator), test => test);
        
        foreach (var classActivation in discovery)
        {
            var (@class, composer) = classActivation.Key;
            var lifeCycle = @class!.ImplementedInterfaces.Contains(typeof(IZeLifecycle))
                ? @class.ImplementedInterfaces.First(n => n.IsGenericType).GetGenericArguments().First()
                : typeof(TransientLifeCycleFactory);
           
            try
            {
                var factory = (IZeLifeCycleFactory)Activator.CreateInstance(lifeCycle, composer!, @class!)!;
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