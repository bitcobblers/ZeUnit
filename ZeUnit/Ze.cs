namespace ZeUnit;

public static class Ze
{
    public static ZeResult Assert()
    {
        return new ZeResult();
    }
    
    public static void Unit<TActivator>(params Assembly[] assemblies)
        where TActivator : IZeTestActivator, IDisposable, new()
    {
        var testRunner = new ZeRunner<TActivator>();
        var discovery = new ZeDiscovery()
            .FromAssemblies(assemblies);
        
        var reporter = new ZeReporter();

        foreach (var test in discovery)
        {
            var result = testRunner.Run(test);            
            reporter.Report(test, result);
        }
    }
}