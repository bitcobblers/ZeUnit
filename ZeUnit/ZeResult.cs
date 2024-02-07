namespace ZeUnit;

public class ZeResult<TType> : ZeResult
{
    public ZeResult(TType actual) : base(actual) { }

    public TType Value => (TType)Actual!;
}

public class ZeResult : IEnumerable<ZeAssert>
{
    private readonly List<ZeAssert> assertions = new();

    public ZeResult(object? actual)
    {
        Actual = actual;
    }

    public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(0);

    public ZeResult(IEnumerable<ZeAssert> assertions)
    {
        this.assertions.AddRange(assertions);
    }

    public ZeStatus State => this.Aggregate(
        ZeStatus.Passed,
        (sum, current) => current.Status == ZeStatus.Failed ? ZeStatus.Failed : sum);

    public object? Actual { get; }

    public ZeResult Assert(ZeAssert assertion)
    {
        assertions.Add(assertion);
        return this;
    }

    public IEnumerator<ZeAssert> GetEnumerator() => assertions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => assertions.GetEnumerator();
}