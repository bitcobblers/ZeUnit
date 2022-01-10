// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Reporters;

public class TeamCityReporter : IZeReporter
{
    public void Report(ZeTest test, IEnumerable<ZeResult> results)
    {
        foreach (var result in results)
        {
            var state = result.Aggregate(
            ZeStatus.Passed,
            (sum, current) => current.Status == ZeStatus.Failed ? ZeStatus.Failed : sum);

            Console.WriteLine($"[{test.Class.FullName}]::{test.Method.Name} - {state}");
        }
    }
}
