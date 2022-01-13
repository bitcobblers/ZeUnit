namespace ZeUnit;

public class ListTestRunnerDiscovery : ZeTestRunnerDiscovery
{    
    public ListTestRunnerDiscovery(IEnumerable<ZeTestRunner> zeTestRunners)
    {
        this.zeTestRunners.AddRange(zeTestRunners);
    }
}
