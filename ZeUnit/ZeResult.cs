namespace ZeUnit;
public class ZeResult : IEnumerable<ZeAssertion>
{
    private readonly List<ZeAssertion> assertions = new();

    public ZeStatus State => this.Aggregate(
        ZeStatus.Passed,
        (sum, current) => current.Status == ZeStatus.Failed ? ZeStatus.Failed : sum);
        

    public ZeResult Assert(ZeAssertion assertion)
    {
        assertions.Add(assertion);
        return this;
    }

    public IEnumerator<ZeAssertion> GetEnumerator() => assertions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => assertions.GetEnumerator();
}