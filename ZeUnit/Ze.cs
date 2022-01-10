namespace ZeUnit;

public class ZeActivatorAttribute : Attribute
{    
    public Type Activator { get; protected set; }

    protected void WithActivator<TActivator>()
        where TActivator : IZeActivator, IDisposable, new()
    {
        this.Activator = typeof(TActivator);
    }
}

public static class Ze
{
    public static ZeResult Assert()
    {
        return new ZeResult();
    }       

    public static void Unit(Func<ZeDiscovery, ZeDiscovery> config, params IZeReporter[] reporters)        
    {
        var testRunner = new ZeRunner();
        var discovery = config(new ZeDiscovery());                
        foreach (var test in discovery)
        {
            var result = testRunner.Run(test);            
            foreach (var reporter in reporters) {
                reporter.Report(test, result);
            }
        }
    }
}