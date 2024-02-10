using ZeUnit.Assertions;
namespace ZeUnit;

public class Ze<TType> : Ze
{
    public Ze(TType actual) : base(actual) { }

    public TType Value => (TType)Actual!;
}

public class Ze : IEnumerable<ZeAssert>
{
    private readonly List<ZeAssert> assertions = new();

    public Ze(object? actual)
    {
        Actual = actual;
    }

    public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(0);

    public Ze(IEnumerable<ZeAssert> assertions)
    {
        this.assertions.AddRange(assertions);
    }

    public ZeStatus State => this.Aggregate(
        ZeStatus.Passed,
        (sum, current) => current.Status == ZeStatus.Failed ? ZeStatus.Failed : sum);

    public object? Actual { get; }

    public Ze Assert(ZeAssert assertion)
    {
        assertions.Add(assertion);
        return this;
    }

    public IEnumerator<ZeAssert> GetEnumerator() => assertions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => assertions.GetEnumerator();

    public static implicit operator Ze(bool outcome) => new Ze<bool>(outcome).True();
    public static implicit operator Ze((bool, string) outcome) => new Ze<bool>(outcome.Item1).True(outcome.Item2);

}