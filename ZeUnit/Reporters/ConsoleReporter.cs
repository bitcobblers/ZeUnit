// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Reporters;

public class CompoundReporter : IZeReporter
{
    private List<IZeReporter> reporters;

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

    public void OnNext((ZeTest, ZeResult) value)
    {
        reporters.ForEach(reporter => reporter.OnNext(value));
    }
}


public class ConsoleReporter : IZeReporter
{
    private int total = 0;
    private int error = 0;

    public void OnNext((ZeTest, ZeResult) value)
    {
        var (test, result) = value;
        Console.WriteLine($"[{test.Class.FullName}]::{test.Method.Name} - {result.State}");
        foreach (var assertion in result)
        {
            Console.WriteLine($" -- {assertion.Message}");
        }

        if (result.State == ZeStatus.Failed)
        {
            error++;
        }
        total++;
    }

    public void OnError(Exception error)
    {
        this.error++;
        Console.WriteLine($" ERROR: {error.Message}");
        Console.WriteLine($" ERROR: {error.StackTrace}");
    }

    public void OnCompleted()
    {
        Console.WriteLine($"Test completed with {error} out of {total}.");
    }    
}