using ZeUnit.Reporters;

namespace ZeUnit;

public class ZeBuilder
{
    private readonly List<Func<ZeDiscovery, ZeDiscovery>> _configs = new();
    private readonly List<IZeReporter> _reporters = new();
    private readonly IZeTestRunnerDiscovery _runnerDiscovery;    

    public ZeBuilder() : this(new DefaultTestRunnerDiscovery())
    {        
    }
    public ZeBuilder(IZeTestRunnerDiscovery runnerDiscovery)
    {
        this._runnerDiscovery = runnerDiscovery;       
    }

    public ZeBuilder With(Func<ZeDiscovery, ZeDiscovery> configFn)
    {
        this._configs.Add(configFn);
        return this;
    }

    public ZeBuilder With(params IZeReporter[] reporters)
    {
        this._reporters.AddRange(reporters);
        return this;
    }            

    public ZeDiscovery GetDiscovery()
    {
        var discovery = new ZeDiscovery(_runnerDiscovery.SupportedTypes());
        return _configs.Aggregate(discovery, (discovery, config) => config(discovery));        
    }

    public IZeReporter GetReporter()
    {
        return (CompoundReporter)this._reporters;
    }

    public IEnumerable<ZeTestRunner> Runners()
    {
        return _runnerDiscovery.Runners();
    }
}
