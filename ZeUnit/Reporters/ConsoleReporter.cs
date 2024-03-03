// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Reporters;

public class ConsoleReporter : IZeReporter
{
    private int total;
    private int error;

    public void OnNext((ZeTest, Fact) value)
    {
        var (test, result) = value;
        Console.WriteLine($"[{test.Class!.FullName}]::{test.Method!.Name} - {result.State}");
        foreach (var assertion in result)
        {
            Console.WriteLine($" -- {assertion}");
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