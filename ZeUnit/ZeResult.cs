namespace ZeUnit;
public class ZeResult : IEnumerable<ZeAssertion>
{
    private readonly List<ZeAssertion> assertions = new();

    public ZeResult Assert(ZeAssertion assertion)
    {
        assertions.Add(assertion);
        return this;
    }

    public IEnumerator<ZeAssertion> GetEnumerator() => assertions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => assertions.GetEnumerator();
}