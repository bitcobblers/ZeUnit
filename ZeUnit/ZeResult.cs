namespace ZeUnit;
public class ZeResult : IEnumerable<ZeAssert>
{
    private readonly List<ZeAssert> assertions = new();

    public ZeStatus State => this.Aggregate(
        ZeStatus.Passed,
        (sum, current) => current.Status == ZeStatus.Failed ? ZeStatus.Failed : sum);
        

    public ZeResult Assert(ZeAssert assertion)
    {
        assertions.Add(assertion);
        return this;
    }

    public IEnumerator<ZeAssert> GetEnumerator() => assertions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => assertions.GetEnumerator();
}