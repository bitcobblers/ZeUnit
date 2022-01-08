namespace ZeUnit;

public static class Ze
{
    public static ZeResult Assert()
    {
        return new ZeResult();
    }
    
    public static void Unit(params Assembly[] assemblies)
    {
        var discovery = new ZeDiscovery().FromAssemblies(assemblies);
        var testRunner = new ZeRunner();
        var reporter = new ZeReporter();        

        foreach (var test in discovery)
        {
            var result = testRunner.Run(test);
            // TODO: Add some error handling.
            // TODO: updated this to be async by default, with a Task.Run around sync functions.

            reporter.Report(test, result);
        }

    }
}