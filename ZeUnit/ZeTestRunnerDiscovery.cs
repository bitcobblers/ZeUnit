namespace ZeUnit;

public abstract class ZeTestRunnerDiscovery : IZeTestRunnerDiscovery
{
    protected List<ZeTestRunner> zeTestRunners = new();

    public virtual Type[] SupportedTypes() => zeTestRunners.Select(n => n.SupportType).ToArray();
    public virtual ZeTestRunner[] Runners() => zeTestRunners.ToArray();
}
