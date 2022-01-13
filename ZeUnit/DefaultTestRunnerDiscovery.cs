namespace ZeUnit;
public class DefaultTestRunnerDiscovery : ZeTestRunnerDiscovery
{
    public DefaultTestRunnerDiscovery()
    {
        var types = this.GetType().Assembly
            .GetExportedTypes()
            .Where(n => n.IsAssignableTo(typeof(ZeTestRunner)))
            .Where(n => !n.IsAbstract);

        foreach (var type in types)
        {
            this.zeTestRunners.Add((ZeTestRunner)Activator.CreateInstance(type));
        }
    }
}