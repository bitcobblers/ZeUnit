// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Reporters;

public class ConsoleReporter : IZeReporter
{
    public void Report(ZeTest test, ZeResult result)
    {        
        Console.WriteLine($"[{test.Class.FullName}]::{test.Method.Name} - {result.State}");
        foreach (var assertion in result) {
            Console.WriteLine($" -- {assertion.Message}");
        }
    }
}