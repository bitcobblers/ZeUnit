// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Reporters;

public class ConsoleReporter : IZeReporter
{
    private int total = 0;
    private int error = 0;

    public void Report(ZeTest test, ZeResult result)
    {                
        Console.WriteLine($"[{test.Class.FullName}]::{test.Method.Name} - {result.State}");
        foreach (var assertion in result) {
            Console.WriteLine($" -- {assertion.Message}");
        }        

        if (result.State == ZeStatus.Failed)
        {
            error++;
        }
        total++;
    }

    public void Close()
    {
        Console.WriteLine($"Test completed with {error} out of {total}.");
    }
}