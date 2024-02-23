namespace ZeUnit;

using System.Reactive.Linq;

public static class ZeGlobal
{        
    public static IObservable<(ZeTest, Fact)> Unit(ZeBuilder builder)   
    {
        var classRuns = new List<IObservable<(ZeTest, Fact)>>();
        var reporter = builder.GetReporter();
        var discovery = builder.GetDiscovery()
            .GroupBy(test => (test.Class, test.ClassFactory) , test => test);
              
        foreach (var classActivation in discovery)
        {
            var (@class, factory) = classActivation.Key;
                                  
            try
            {                                
                classRuns.AddRange(classActivation
                    .Select(test => new ZeRunner(builder.Runners()).Run(test, factory!)));
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