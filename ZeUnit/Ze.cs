namespace ZeUnit;

public static class Ze
{
    public static ZeResult Assert()
    {
        return new ZeResult();
    }
    
    public static void Unit<TActivator>(Func<ZeDiscovery, ZeDiscovery> config, params IZeReporter[] reporters)
        where TActivator : IZeTestActivator, IDisposable, new()
    {
        var testRunner = new ZeRunner<TActivator>();
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