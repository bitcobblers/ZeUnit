namespace ZeUnit;

using System.Reactive.Linq;
using System.Reactive;
using ZeUnit.Reporters;

public class ZeBuilder
{
    private List<Func<ZeDiscovery, ZeDiscovery>> configs = new();
    private List<IZeReporter> reporters = new();
    private IZeTestRunnerDiscovery runnerDiscovery;    

    public ZeBuilder() : this(new DefaultTestRunnerDiscovery())
    {        
    }
    public ZeBuilder(IZeTestRunnerDiscovery runnerDiscovery)
    {
        this.runnerDiscovery = runnerDiscovery;       
    }

    public ZeBuilder With(Func<ZeDiscovery, ZeDiscovery> configFn)
    {
        this.configs.Add(configFn);
        return this;
    }

    public ZeBuilder With(params IZeReporter[] reporters)
    {
        this.reporters.AddRange(reporters);
        return this;
    }            

    public ZeDiscovery GetDiscovery()
    {
        var discovery = new ZeDiscovery(runnerDiscovery.SupportedTypes());
        return configs.Aggregate(discovery, (discovery, config) => config(discovery));        
    }

    public IZeReporter GetReporter()
    {
        return new CompoundReporter(this.reporters);
    }

    public IEnumerable<ZeTestRunner> Runners()
    {
        return runnerDiscovery.Runners();
    }
}

public static class Ze
{    
    public static ZeResult Is => new ZeResult();

    public static Dictionary<string, object> Global = new();

    public static IObservable<(ZeTest, ZeResult)> Unit(ZeBuilder builder)   
    {
        var classRuns = new List<IObservable<(ZeTest, ZeResult)>>();
        var reporter = builder.GetReporter();
        var discovery = builder.GetDiscovery()
            .GroupBy(test => (test.Class, test.ClassActivator), test => test);
        
        foreach (var classActivation in discovery)
        {
            var (@class, composer) = classActivation.Key;            
            var lifeCycle = @class
                .GetCustomAttribute<ZeLifeCycleAttribute>() ?? (ZeLifeCycleAttribute)new TransientAttribute();
            try
            {
                var factory = lifeCycle.GetFactory(composer, @class);

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