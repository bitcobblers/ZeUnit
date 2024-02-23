namespace ZeUnit;

using System.Reactive.Linq;
using System.Reactive;
using ZeUnit.Reporters;
using ZeUnit.Assertions;

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
        return (CompoundReporter)this.reporters;
    }

    public IEnumerable<ZeTestRunner> Runners()
    {
        return runnerDiscovery.Runners();
    }
}
