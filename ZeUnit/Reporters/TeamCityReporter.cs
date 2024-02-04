// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Reporters;

public class TeamCityReporter : IZeReporter
{
    public void OnNext((ZeTest, ZeResult) value)
    {
        var (test, result) = value;
        Console.WriteLine($"TeamCity::[{test.Class?.FullName}]::{test.Method?.Name} - {result.State}");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($" ERROR: {error.Message}");
        Console.WriteLine($" ERROR: {error.StackTrace}");
    }

    public void OnCompleted()
    {
    }
}
