using ZeUnit.Assertions;
namespace ZeUnit;

public class Fact<TType> : Fact
{
    public Fact(TType actual) : base(actual) { }

    public TType Value => (TType)Actual!;
}


public class Fact : IEnumerable<ZeAssert>
{
    private readonly List<ZeAssert> assertions = new();

    public Fact(object? actual)
    {
        Actual = actual;
    }

    public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(0);

    public Fact(IEnumerable<ZeAssert> assertions)
    {
        this.assertions.AddRange(assertions);
    }

    public ZeStatus State => this.Aggregate(
        ZeStatus.Passed,
        (sum, current) => current.Status == ZeStatus.Failed ? ZeStatus.Failed : sum);

    public object? Actual { get; }

    public Fact Assert(ZeAssert assertion)
    {
        assertions.Add(assertion);
        return this;
    }

    public IEnumerator<ZeAssert> GetEnumerator() => assertions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => assertions.GetEnumerator();

    public static implicit operator Fact(bool outcome) => new Fact<bool>(outcome).True();
    public static implicit operator Fact((bool, string) outcome) => new Fact<bool>(outcome.Item1).True(outcome.Item2);

}