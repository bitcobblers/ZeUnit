// See https://aka.ms/new-console-template for more information

using ZeUnit;

public class ConsoleReporter : IZeReporter
{    
    public void Report(ZeTest test, ZeResult? result)
    {
        var state = result.Aggregate(
        ZeStatus.Passed,
        (sum, current) => current.Status == ZeStatus.Failed ? ZeStatus.Failed : sum);

        Console.WriteLine($"[{test.Class.FullName}]::{test.Method.Name} - {state}");
    }
}