// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Reporters;

public class CompoundReporter : IZeReporter
{
    private readonly List<IZeReporter> reporters;

    public CompoundReporter(List<IZeReporter> reporters)
    {
        this.reporters = reporters;
    }

    public void OnCompleted()
    {
        reporters.ForEach(reporter => reporter.OnCompleted());
    }

    public void OnError(Exception error)
    {
        reporters.ForEach(reporter => reporter.OnError(error));
    }

    public void OnNext((ZeTest, Fact) value)
    {
        reporters.ForEach(reporter => reporter.OnNext(value));
    }

    public static implicit operator CompoundReporter(List<IZeReporter> reporters) => new(reporters);
}
