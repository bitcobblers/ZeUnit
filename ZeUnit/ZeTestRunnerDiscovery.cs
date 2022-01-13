namespace ZeUnit;

public abstract class ZeTestRunnerDiscovery
{
    protected List<ZeTestRunner> zeTestRunners = new List<ZeTestRunner>();

    public virtual Type[] SupportedTypes() => zeTestRunners.Select(n => n.SupportType).ToArray();
    public virtual ZeTestRunner[] Runners() => zeTestRunners.ToArray();
}
